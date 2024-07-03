using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetBooks.Model
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public string Book_id { get; set; }
        [ForeignKey("Book_id")]
        public Books Books { get; set; }
    }
}
