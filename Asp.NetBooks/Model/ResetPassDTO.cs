using System.ComponentModel.DataAnnotations;

namespace Asp.NetBooks.Model
{
    public class ResetPassDTO
    {
        public string token {  get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword {  get; set; }
    }
}
