namespace Asp.NetBooks.Model
{
    public class Response
    {
        public string Error {  get; set; }
        public bool Result {  get; set; }
        public string Token {  get; set; }
        public string RefreshToken {  get; set; }
        public IList<string> role { get; set; }
        public string id {  get; set; }

    }
}
