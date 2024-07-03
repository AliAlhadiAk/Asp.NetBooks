using System.Diagnostics;

namespace Asp.NetBooks.NewFolder
{
    public class ProfilingMiddleWare
    {
        private readonly ILogger<ProfilingMiddleWare> _logger;
        private readonly RequestDelegate _next;

        public ProfilingMiddleWare(ILogger<ProfilingMiddleWare> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
           await  _next(context);
            stopwatch.Stop();
            _logger.LogInformation($"Request {context.Request.Path} took {stopwatch.ElapsedMilliseconds} to execute");
        }
    }
}
