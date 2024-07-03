using Asp.NetBooks.DbContext;
using Asp.NetBooks.Model;
using Asp.NetBooks.NewFolder;
using Asp.NetBooks.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Web.Http.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

 

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });



    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy
            .WithOrigins("http://localhost:5173", "http://localhost:3003")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<JwtAuthentication>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddSingleton(sp =>
{
    var jwtOptions = sp.GetRequiredService<IOptions<JwtAuthentication>>().Value;
    return jwtOptions;
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidIssuer = "https://localhost:7189/api",
        ValidAudience = "https://localhost:7189",
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateLifetime = true
    };
})
.AddFacebook(options =>
{
    options.AppId = "1593257571249146";
    options.AppSecret = "8766a055f15da3136f8946b35fb085ed";
});

builder.Services.AddScoped<ICacheServices, CacheService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseMiddleware<RateLimitingMiddleWare>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
