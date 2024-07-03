using Microsoft.Identity.Client;

namespace Asp.NetBooks.Model
{
    public class OrderHistoryResponse
    {
        public DateTime? TimeRented { get; set; }
        
        public object RentedBooks { get; set; }
        public DateTime? TimeBuyed { get; set; }
        public object BuyedBooks {  get; set; }

    }
}
