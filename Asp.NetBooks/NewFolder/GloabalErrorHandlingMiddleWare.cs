using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace Asp.NetBooks.NewFolder
{
    public class GlobalErrorHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private ILogger<GlobalErrorHandlingMiddleWare> _logger;

        public GlobalErrorHandlingMiddleWare(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        private async Task invokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
              //  context.Request.
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                var details = new ProblemDetails
                {
                    Detail = "Internal server error",
                    Instance = "error",
                    Status = 500,
                    Title = "Server Error",
                    Type = "Error"
                };
                var response = 
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("An error had occured");


            }
        }
    }
}
