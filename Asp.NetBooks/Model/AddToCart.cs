using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetBooks.Model
{
    public class AddToCart
    {
        [Key]
        public int Id { get; set; }
        public string User_id { get; set; }
        [ForeignKey(nameof(User_id))]
        public User User { get; set; }
        public string BookId {  get; set; }
        [ForeignKey(nameof(BookId))]
        public Books Books { get; set; }
    }
}
