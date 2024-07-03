
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;
using Asp.NetBooks.DbContext;
using Asp.NetBooks.Model;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;
using System.Collections.Immutable;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;


namespace AuthenticationReact.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly JwtAuthentication _jwt;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ConfigurationManager _configurationManager;




        public AuthenticationController(AppDbContext appDbContext, JwtAuthentication jwt, UserManager<User> userManager, ILogger<AuthenticationController> logger,
            RoleManager<IdentityRole> roleManager
            )
        {
            _appDbContext = appDbContext;
            _jwt = jwt;
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;


        }

        [HttpPost]
        [Route("seed-roles")]

        public async Task<IActionResult> SeedRoles()
        {
            var checkAdmin = await _roleManager.RoleExistsAsync(UserROLES.Admin);
            var checkUser = await _roleManager.RoleExistsAsync(UserROLES.User);

            if (checkAdmin && checkUser)
            {
                return Ok("Roles are already seeded");
            }

            await _roleManager.CreateAsync(new IdentityRole(UserROLES.Admin));
            await _roleManager.CreateAsync(new IdentityRole(UserROLES.User));
            return Ok("Roles have been seeded successfully");
        }
        [HttpGet]
        [Authorize]
       

        public IActionResult GetPrices()
        {
            return Ok("yahala bl 5al");
        }

        [HttpGet("userInfo")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo(Guid userId)
        {
            var checkUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId.ToString());
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (checkUser == null)
            {
                return BadRequest("undefined user");
            }
            return Ok(checkUser);

        }

        [HttpPost]
        [Route("Login")]


        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please fill in the credentials");
            }

            var checkEmail = await _userManager.FindByEmailAsync(dto.email);
            if (checkEmail == null)
            {
                return BadRequest("Please register before you login");
            }

            var checkPass = await _userManager.CheckPasswordAsync(checkEmail, dto.pwd);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, dto.email),
                new Claim(JwtRegisteredClaimNames.Name, dto.email)
            };

            var userRoles = await _userManager.GetRolesAsync(checkEmail);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            if (checkPass)
            {
                var token = GenerateToken(claims);
                var refresh = GenerateRefreshToken();
                checkEmail.RefreshToken = refresh;
                checkEmail.RefreshTokenExpiry = DateTime.Now.AddDays(7);
                await _appDbContext.SaveChangesAsync();

                return Ok(new Asp.NetBooks.Model.Response()
                {
                    Error = "Welcome back",
                    Result = true,
                    Token = token,
                    RefreshToken = refresh,
                    role = userRoles,
                    id = checkEmail.Id



                });

            }

            return Unauthorized(); // Return Unauthorized if the password is incorrect
        }
        [HttpGet("id")]
        [Authorize]
        public IActionResult GetUser(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = _appDbContext.Users.Find(id.ToString());
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
        [HttpPost]

        [Route("Sign-Up")]


        public async Task<IActionResult> SignUp(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please fill in the credentials");
            }

            var checkEmail = await _userManager.FindByEmailAsync(dto.email);
            if (checkEmail != null)
            {
                return BadRequest("Email already exists");
            }

            var account = new User
            {
                Email = dto.email,
                UserName = dto.UserName,
                Avatar = dto.Avatar,
                Address = dto.Address
            };

            var checkPass = await _userManager.CreateAsync(account, dto.pwd);

            if (!checkPass.Succeeded)
            {
                var errors = string.Join(", ", checkPass.Errors.Select(e => e.Description));
                return BadRequest($"Failed to create user account: {errors}");
            }

            var claims = new List<Claim>()
    {
        new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Email, dto.email),
        new Claim(JwtRegisteredClaimNames.Name, dto.email)
    };
            

            if (dto.email == "alialhadiabokhalil@gmail.com")
            {
                var roleResult = await _userManager.AddToRoleAsync(account, UserROLES.Admin);
                if (!roleResult.Succeeded)
                {
                    var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    return BadRequest($"Failed to assign admin role: {errors}");
                }
            }
            else
            {
                var roleResult = await _userManager.AddToRoleAsync(account, UserROLES.User);
                if (!roleResult.Succeeded)
                {
                    var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    return BadRequest($"Failed to assign user role: {errors}");
                }
            }

            var userRoles = await _userManager.GetRolesAsync(account);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = GenerateToken(claims);
            var refresh = GenerateRefreshToken();
            account.RefreshToken = refresh;
            account.RefreshTokenExpiry = DateTime.Now.AddDays(7);
            await _appDbContext.SaveChangesAsync();

            return Ok(new Asp.NetBooks.Model.Response()
            {
                Error = "Welcome back",
                Result = true,
                Token = token,
                RefreshToken = refresh,
                role = userRoles,
                id = account.Id

            });

        }
        [HttpPost("/api/token/refresh")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
        {
            // Verify the refresh token
            var refreshToken = await _appDbContext.Users.FirstOrDefaultAsync(x => x.RefreshToken == request.RefreshToken);
            if (refreshToken == null || refreshToken.RefreshTokenExpiry < DateTime.UtcNow)
            {
                return BadRequest("Invalid or expired refresh token");
            }

            // Get the user associated with the refresh token
            /*var user = await _userManager.FindByIdAsync(refreshToken.UserName);
            if (user == null)
            {
                return BadRequest("Invalid refresh token");
            }*/
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, refreshToken.Email),
                new Claim(JwtRegisteredClaimNames.Name, refreshToken.Email)
            };

            var userRoles = await _userManager.GetRolesAsync(refreshToken);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Generate a new access token and refresh token
            var accessToken = GenerateToken(claims);
            var newRefreshToken = GenerateRefreshToken();

            // Update the refresh token in the database
            refreshToken.RefreshToken = newRefreshToken;
            refreshToken.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7); // Set the new expiration date
            //_appDbContext.Users.Update(refreshToken);
            await _appDbContext.SaveChangesAsync();

            // Return the new access token and refresh token
            return Ok(new Asp.NetBooks.Model.Response()
            {
                Result = true,
                Error = "You have now anew acces token",
                Token = accessToken,
                RefreshToken = newRefreshToken,
                role = userRoles
            });
        }


        [HttpPost("/api/ForgotPassword")]
        public async Task<IActionResult> ForgotPass(string Email)
        {
            var checkEmail = await _userManager.FindByEmailAsync(Email);
            if (checkEmail == null)
            {
                return BadRequest("email doesn't exist");
            }
            var ResetToken = await _userManager.GeneratePasswordResetTokenAsync(checkEmail);

            // await SendPasswordResetEmail(Email, "www.google.com");
            checkEmail.ResetToken = ResetToken;
            checkEmail.ResetTokenExpiry = DateTime.Now.AddDays(1);
            SendEmail(Email);
            _logger.LogInformation("Send EmailSuccefully");

            await _appDbContext.SaveChangesAsync();

            return Ok($"{ResetToken}");
        }
        [HttpPost("/api/ResetPassword")]

        public async Task<IActionResult> ResetPassword(ResetPassDTO dto)
        {
            var checkEmail = await _appDbContext.Users.FirstOrDefaultAsync(x => x.ResetToken == dto.token);
            if (checkEmail == null)
            {
                return BadRequest("email doesn't exist");
            }
            await _userManager.ResetPasswordAsync(checkEmail, dto.token, dto.ConfirmPassword);
            return Ok("password ResetSuccefully");

        }





        private string GenerateToken(List<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwt.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var tokenCreate = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(tokenCreate);
            return token.ToString();
        }
        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }


       
        private void SendEmail(string email)
        {
            string senderEmail = EmailSender.Email; // Replace with your Outlook email address
            string senderPassword = EmailSender.Pass; // Replace with your Outlook email password

            // Recipient's email address
            string recipientEmail = email;

            // Outlook SMTP server address and port
            string smtpServer = "smtp.office365.com";
            int smtpPort = 587; // Outlook SMTP port (TLS)

            try
            {
                // Create SMTP client and configure credentials
                using (var client = new System.Net.Mail.SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true; // Enable SSL/TLS
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    string link = "https://localhost:7189/swagger/index.html";

                    // Create email message
                    using (var message = new MailMessage(senderEmail, email))
                    {
                        message.Subject = "Forgot Reset Password using al5aaaaaaaaaaaal smtp !!!!!!";
                        message.Body = $"To reset your password please click on the link below {link} ";
                        message.IsBodyHtml = false;

                        // Send email
                        client.Send(message);
                
                       
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email. Error message: {ex.Message}");
             
            }
        }
    }
}

