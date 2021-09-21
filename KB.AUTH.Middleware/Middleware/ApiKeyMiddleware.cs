using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
 
namespace KB.AUTH.Middleware.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string CLIENTID = "ClientID";
        private const string CLIENTSECRET = "ClientSecret";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(CLIENTID, out var extractedClientID) || !context.Request.Headers.TryGetValue(CLIENTSECRET, out var extractedClientSecret))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Client ID or Secret was not provided. ");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

            var clientID = appSettings.GetValue<string>(CLIENTID);
            var clientSecret = appSettings.GetValue<string>(CLIENTSECRET);

            if (!clientID.Equals(extractedClientID) || !clientSecret.Equals(extractedClientSecret))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client.");
                return;
            }

            await _next(context);
        }
    }
}
