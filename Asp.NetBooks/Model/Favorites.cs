using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetBooks.Model
{
    public class Favorites
    {
        public int Id { get; set; }
        public string Book_id { get; set; }


        public string User_Id { get; set; }
        [ForeignKey(nameof(User_Id))]
        public User User { get; set; }
        [ForeignKey(nameof(Book_id))]
        public Books Books { get; set; }
    }
}