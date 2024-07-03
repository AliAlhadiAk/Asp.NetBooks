using System.ComponentModel.DataAnnotations;

namespace Asp.NetBooks.Model
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string email {  get; set; }
        [Required]
        [MinLength(6)]
        public string pwd { get; set; }
    }
}
