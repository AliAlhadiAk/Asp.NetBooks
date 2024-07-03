using System.ComponentModel.DataAnnotations;

namespace Asp.NetBooks.Model
{
    public class RegisterDTO
    {
        [Required]
        public string UserName {  get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MinLength(6)]
        public string pwd { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
