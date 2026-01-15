using System.Net;

namespace WebApi_Courcera.Models
{
    public class CustomAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Example: read token from header
            if (!context.Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("API Key is missing");
                return;
            }

            // Validate key (demo logic)
            if (apiKey != "MY_SECRET_KEY")
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            // If valid → continue pipeline
            await _next(context);
        }

    }
}
