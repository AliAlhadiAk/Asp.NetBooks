namespace Asp.NetBooks.Model
{
    public class AddBooksDTO
    {
        public string Books_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public double Rental_Price { get; set; }
        public string language { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
