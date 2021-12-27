using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;

namespace UtopiaCity.Common.Middleware
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                try
                {
                    var culture = new CultureInfo(cultureQuery);

                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;
                    context.Response.Headers.Add("culture", culture.Name);
                }
                catch (CultureNotFoundException e)
                {
                    context.Response.Headers.Add("culture-error", $"{e.Message}");
                }
            }

            await _next(context);
        }
    }
}
