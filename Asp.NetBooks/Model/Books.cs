using System.ComponentModel.DataAnnotations;

namespace Asp.NetBooks.Model
{
    public class Books
    {
        [Key]
        public string Books_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public double Rental_Price { get; set; }
        public string language { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<RentBooks> RentBooks { get; set; }
        public ICollection<PurchaseBooks> PurchaseBooks { get; set; }
        public List<User> Users { get; set; }
        public List<Favorites> Favorites { get; set; }
        public List<AddToCart> addToCarts { get; set; }

        public int QuantityAvailable { get; set; }
    }
}
