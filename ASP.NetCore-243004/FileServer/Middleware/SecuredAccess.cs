using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FileServer.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SecuredAccess
    {
        private const string ApiKeyHeaderName = "X-API-Key";
        private const string ApiKey = "7F12CA09-0EE3-461B-8BA2-3059E3A855CD"; // kann beliebiger string sein

        private readonly RequestDelegate _next;

        public SecuredAccess(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "GET")
            {
                // GET benoetigen kein API-Key, d. h. Bilder koennen jederzeit abgerufen werden
                await _next(context);
            }

            if (context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey)
                && extractedApiKey.ToString() == ApiKey)
            {
                await _next(context);
            } 
            else
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized");
            }

            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSecuredAccess(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecuredAccess>();
        }
    }
}
