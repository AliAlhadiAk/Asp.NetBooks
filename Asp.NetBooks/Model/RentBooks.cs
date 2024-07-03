using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetBooks.Model
{
    public class RentBooks
    {
        [Key]
        public int Id { get; set; }
        public string User_id { get; set; } // Change to string
        [ForeignKey(nameof(User_id))]
        public User User { get; set; }
        public string Books_id { get; set; }
        [ForeignKey(nameof(Books_id))]
        public Books Books { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
