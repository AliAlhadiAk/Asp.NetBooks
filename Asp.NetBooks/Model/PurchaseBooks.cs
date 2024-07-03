using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetBooks.Model
{
    public class PurchaseBooks
    {
        [Key]
        public int Purchase_Id { get; set; }
        public string Books_Id { get; set; }
        [ForeignKey(nameof(Books_Id))]
        public Books Books { get; set; }
        public string User_Id { get; set; } // Change to string
        [ForeignKey(nameof(User_Id))]
        public User User { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double PricePaid { get; set; }
    }
}
