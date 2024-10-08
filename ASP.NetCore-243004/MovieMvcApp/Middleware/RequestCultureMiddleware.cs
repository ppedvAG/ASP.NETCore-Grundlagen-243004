using System.Globalization;

namespace MovieMvcApp.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var cultureCode = httpContext.Request.Query["culture"].ToString();
            if (!string.IsNullOrEmpty(cultureCode))
            {
                var culture = new CultureInfo(cultureCode);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestCultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCultureMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCultureMiddleware>();
        }
    }
}
