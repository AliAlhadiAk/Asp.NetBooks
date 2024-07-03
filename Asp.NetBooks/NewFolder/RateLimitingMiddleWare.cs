namespace Asp.NetBooks.NewFolder
{
    public class RateLimitingMiddleWare
    {
        private readonly RequestDelegate next;
        private static int counter = 0;
        private static DateTime lastRequestDate = DateTime.Now;

        public RateLimitingMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            counter++;
            if (DateTime.Now.Subtract(lastRequestDate).Seconds > 10)
            {
                counter = 1;
                lastRequestDate = DateTime.Now;
                await next(context);
            }
            else
            {
                if(counter>5)
                {
                    await context.Response.WriteAsync("rate limit exceeded");
                     context.Response.StatusCode = 500;
                }
                else
                {
                    lastRequestDate = DateTime.Now;
                    await next(context);
                }
            }
        }
    }
}
