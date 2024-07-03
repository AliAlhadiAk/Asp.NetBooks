using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetBooks.Model
{
    public class User:IdentityUser
    {
        
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public ICollection<PurchaseBooks> PurchaseBooks { get; set; }
        public ICollection<RentBooks> RentBooks { get; set; }
        public ICollection<Favorites> Favorites { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Books> Books { get; set; }
        public List<AddToCart> addToCarts { get; set; }
    }
}
