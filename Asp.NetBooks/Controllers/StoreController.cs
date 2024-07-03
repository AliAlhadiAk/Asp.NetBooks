using Asp.NetBooks.DbContext;
using Asp.NetBooks.Migrations;
using Asp.NetBooks.Model;
using Asp.NetBooks.Services;
using AuthenticationReact.Controllers;
using Azure.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using System.Collections.Immutable;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.ComponentModel;
using Asp.NetBooks.NewFolder;
using Microsoft.Identity.Client;
using Microsoft.CodeAnalysis;
using System.Collections;

namespace BookStoreMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StoreController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<StoreController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICacheServices _cacheServices;
        private readonly IConfiguration _configuration;



        public StoreController(AppDbContext appDbContext, UserManager<User> userManager, ILogger<StoreController> logger, ICacheServices cacheServices, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _logger = logger;
            _cacheServices = cacheServices;
            _configuration = configuration;

        }

        [HttpGet("get/recents")]

        public IActionResult RecentlyAdded()
        {
            var cacheRecents = _cacheServices.GetData<IEnumerable<Books>>("recents");
            if (cacheRecents == null)
            {
                return Ok(cacheRecents);
            }
            var products = _appDbContext.Books.Take(4).OrderBy(x => x.Books_Id).ToList();
            _cacheServices.SetData<IEnumerable<Books>>("recents", products, DateTimeOffset.Now.AddMinutes(2));
            return Ok(products);
        }

        [HttpGet("get/products")]
     //   [ServiceFilter(typeof(ApiKeyAuthFilter))]
        [EnableCors("AllowSpecificOrigin")]
        public async Task<IActionResult> GetProducts()
        {
            var cacheBook = _cacheServices.GetData<IEnumerable<Books>>("books");
            if (cacheBook != null)
            {
                return Ok(cacheBook);
            }
            var cacheexp = DateTimeOffset.Now.AddMinutes(2);
            var products = await _appDbContext.Books.ToListAsync();
            _cacheServices.SetData<IEnumerable<Books>>("books", products, cacheexp);

            return Ok(products);
        }
        [HttpGet("id")]
        [EnableCors("AllowSpecificOrigin")]
        public async Task<IActionResult> GetbyId(int id)
        {
            if (!ModelState.IsValid || id == 0)
            {
                return BadRequest("Invalid request");
            }
            var product = await _appDbContext.Books.FindAsync(id.ToString());
            return Ok(product);
        }

        [HttpPost("AddToCart")]
        [EnableCors("AllowSpecificOrigin")]

        public async Task<IActionResult> AddToCartuser(Guid userId, string BookId)
        {




            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var addCart = new AddToCart
            {
                BookId = BookId.ToString(),
                User_id = userId.ToString(),
            };
            var checkBookquan = await _appDbContext.Books.FirstOrDefaultAsync(x => x.Books_Id == BookId);

            await _appDbContext.AddToCart.AddAsync(addCart);
            await _appDbContext.SaveChangesAsync();
            return Ok("Added To Cart Succefully");

        }
        [HttpGet("GetAddToCart")]
        [EnableCors("AllowSpecificOrigin")]

        public async Task<IActionResult> GetToCartuser(Guid userId)
        {

            var cacheexp = DateTimeOffset.Now.AddMinutes(2);


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var checkUser = await _appDbContext.Users.FindAsync(userId.ToString());


            if (checkUser == null)
            {
                return BadRequest();
            }

            var cart = _appDbContext.AddToCart.Where(x => x.User_id == userId.ToString()).Select(x => x.Books).ToList();

            return Ok(cart);






        }

        [HttpPost("Rent")]
        [EnableCors("AllowSpecificOrigin")]
        public async Task<IActionResult> RentBooks(Guid userId, int bookId)
        {
            var book = await _appDbContext.Books.FindAsync(bookId.ToString());
            var user = await _appDbContext.Users.FindAsync(userId.ToString());

            if (book == null || book.QuantityAvailable == 0)
            {
                return BadRequest("This book is now out of stock.");
            }
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var rental = new RentBooks
            {
                User_id = userId.ToString(),
                Books_id = bookId.ToString(),
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(30),
            };

            var inventory = new Inventory
            {
                Book_id = bookId.ToString()
            };

            book.QuantityAvailable--;

            var time = DateTimeOffset.Now.AddMinutes(2);

            await _appDbContext.RentBooks.AddAsync(rental);
            await _appDbContext.Invenntory.AddAsync(inventory);
            await _appDbContext.SaveChangesAsync();
            _cacheServices.RemoveData("inventory");


            return Ok("You rented the book successfully.");
        }
  

        [HttpPost("Buy")]
        [EnableCors("AllowSpecificOrigin")]

        public async Task<IActionResult> BuyBooks(Guid userId, int bookId)
        {
            var book = await _appDbContext.Books.FindAsync(bookId.ToString());
            var user = await _appDbContext.Users.FindAsync(userId.ToString());

            if (book == null || book.QuantityAvailable == 0)
            {
                return BadRequest("This book is now out of stock.");
            }

            var buy = new PurchaseBooks
            {
                User_Id = userId.ToString(),
                Books_Id = bookId.ToString(),
                PurchaseDate = DateTime.Now,
                PricePaid = book.Price,
            };

            var inventory = new Inventory
            {
                Book_id = bookId.ToString()
            };

            book.QuantityAvailable--;

            await _appDbContext.Invenntory.AddAsync(inventory);
            await _appDbContext.PurchaseBooks.AddAsync(buy);
            await _appDbContext.SaveChangesAsync();

            return Ok("You bought the book successfully.");
        }
        [HttpPost("AddBooksAdmin")]
        [EnableCors("AllowSpecificOrigin")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> addBooksAdminn(AddBooksDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please fill requirements");
            }
            var addBook = new Books
            {
                Books_Id = dto.Books_Id,
                Description = dto.Description,
                Author = dto.Author,
                language = dto.language,
                QuantityAvailable = dto.QuantityAvailable,
                Url = dto.Url,
                Name = dto.Name,
                Price = dto.Price,
                Rental_Price = dto.Rental_Price
            };
            await _appDbContext.AddAsync(addBook);
            await _appDbContext.SaveChangesAsync();
            var products = await _appDbContext.Books.ToListAsync();
            _cacheServices.UpdateData<IEnumerable<Books>>("books", products, DateTimeOffset.Now.AddMinutes(2));
            return Ok("Books Are AddedSuccefully");
        }



        [HttpPut("EditBooksAdmin")]

        [EnableCors("AllowSpecificOrigin")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> EditBooksAdmin(AddBooksDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Please fill all requirements");
                }

                var existingBook = await _appDbContext.Books.FindAsync(dto.Books_Id);

                if (existingBook == null)
                {
                    return BadRequest("Book not found");
                }

                existingBook.Description = dto.Description;
                existingBook.Author = dto.Author;
                existingBook.language = dto.language; // Corrected property name
                existingBook.QuantityAvailable = dto.QuantityAvailable;
                existingBook.Url = dto.Url;
                existingBook.Name = dto.Name;
                existingBook.Price = dto.Price;
                existingBook.Rental_Price = dto.Rental_Price;

                _appDbContext.Update(existingBook);
                var products = await _appDbContext.Books.ToListAsync();
                _cacheServices.UpdateData<IEnumerable<Books>>("books", products, DateTimeOffset.Now.AddMinutes(2));
                await _appDbContext.SaveChangesAsync();


                return Ok($"Book with ID {existingBook.Books_Id} has been successfully updated");
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                _logger.LogError(ex, "An error occurred while updating the book");

                return BadRequest("An error occurred while updating the book");
            }
        }
        [HttpDelete("DeleteBooksAdmin")]

        [EnableCors("AllowSpecificOrigin")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult DeleteBookAdmin(string book_id)
        {
            var checkBook = _appDbContext.Books.FirstOrDefault(x => x.Books_Id == book_id.ToString());
            if (checkBook == null)
            {
                return BadRequest();
            }
            _appDbContext.Remove(checkBook);
            _appDbContext.SaveChanges();
            return Ok();
        }





        [HttpPost("Favorites")]
        [EnableCors("AllowSpecificOrigin")]
        [Authorize]


        public async Task<IActionResult> AddFavorites(int bookId, Guid userId)
        {
            var userCheck = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId.ToString());
            var bookCheck = await _appDbContext.Books.FindAsync(bookId.ToString());

            if (userCheck == null || bookCheck == null)
            {
                return BadRequest("Adding to favorites failed.");
            }

            var favoriteBook = new Favorites
            {
                User_Id = userId.ToString(),
                Book_id = bookId.ToString()
            };
            var existingFavorite = await _appDbContext.Favorites
                                         .FirstOrDefaultAsync(f => f.User_Id == userId.ToString() && f.Book_id == bookId.ToString());

            if (existingFavorite != null)
            {
                // Product already favorited by the user
                return BadRequest("Product is already favorited by the user.");
            }
            var favorites = _appDbContext.Favorites.Where(x => x.User_Id == userId.ToString()).Select(x => x.Books).ToList();

            _appDbContext.Favorites.Add(favoriteBook);
            await _appDbContext.SaveChangesAsync();
            _cacheServices.UpdateData<IEnumerable<Books>>($"favorites_{userId}", favorites, DateTimeOffset.Now.AddMinutes(2));


            return Ok("Book added to favorites successfully.");
        }



        [HttpDelete("remove/favorites")]
        [EnableCors("AllowSpecificOrigin")]
        public async Task<IActionResult> RemoveFavoriteBook(Guid userId, int bookId)
        {
            var favoriteBook = await _appDbContext.Favorites
                .FirstOrDefaultAsync(fb => fb.User_Id == userId.ToString() && fb.Book_id == bookId.ToString());

            if (favoriteBook == null)
            {
                return NotFound("Favorite book not found.");
            }

            _appDbContext.Favorites.Remove(favoriteBook);
            _cacheServices.RemoveData($"favorites_{userId}");
            await _appDbContext.SaveChangesAsync();

            return Ok("Book removed from favorites successfully.");
        }

        [HttpGet("get/favorites/id")]
        [EnableCors("AllowSpecificOrigin")]
        [Authorize]
        public async Task<IActionResult> GetFavorites(Guid id)
        {
            var cacheFav = _cacheServices.GetData<IEnumerable<Books>>($"favorites_{id}");
            if (cacheFav != null)
            {
                return Ok(cacheFav);
            }


            var cacheexp = DateTimeOffset.Now.AddMinutes(2);


            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id.ToString());


            if (user is null)
            {
                return NotFound("User not found.");
            }



            var favorites = _appDbContext.Favorites.Where(x => x.User_Id == id.ToString()).Select(x => x.Books).ToList();
            _cacheServices.SetData<IEnumerable<Books>>($"favorites_{id}", favorites, cacheexp);
            return Ok(favorites);

            // var Book = favorites.Include(x => x.Books);


            //   var json = JsonSerializer.Serialize(favorites);

        }

        [HttpGet("get/OrderHistory/id")]
        [EnableCors("AllowSpecificOrigin")]
        [Authorize]
        public async Task<IActionResult> GetOrderHistory(Guid userId)
        {
            var cacheHistory = _cacheServices.GetData<IEnumerable<Inventory>>($"OrderHsitory_{userId}");
            if (cacheHistory != null && cacheHistory.Count() > 0)
            {
                return Ok(cacheHistory);
            }
            var checkUser = await _appDbContext.Users.FirstOrDefaultAsync(x=>x.Id == userId.ToString());
            if(checkUser == null)
            {
                return BadRequest();
            }
            var orderHistoryRent = _appDbContext.RentBooks.Where(x => x.User_id == userId.ToString()).Select(x => x.Books).ToList();
            var orderHistoryBuy = _appDbContext.PurchaseBooks.Where(x => x.User_Id == userId.ToString()).Select(x => x.Books).ToList();
            
           

            return Ok(new OrderHistoryResponse
            {
                RentedBooks = orderHistoryRent,
                BuyedBooks = orderHistoryBuy,
             
                
            });

        }


        [HttpGet("get/Inventory")]
        [EnableCors("AllowSpecificOrigin")]
        [Authorize]
        public async Task<IActionResult> getInventoryAdmin()
        {
            var cacheFav = _cacheServices.GetData<IEnumerable<Inventory>>("inventory");
            if (cacheFav != null && cacheFav.Count() > 0)
            {
                return Ok(cacheFav);
            }
            var cacheexp = DateTimeOffset.Now.AddMinutes(2);
            var sales = _appDbContext.Invenntory.ToList();
            _cacheServices.SetData<IEnumerable<Inventory>>("inventory", sales, cacheexp);
            return Ok(sales);

        }
        
    }
}
