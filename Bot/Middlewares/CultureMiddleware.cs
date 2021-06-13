using System.Globalization;
using System.Threading.Tasks;
using Bot.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using WikipediaNet.Enums;

namespace Bot.Middlewares
{
    public class CultureMiddleware : IMiddleware
    {
        private readonly WikipediaSettings _wikipediaSettings;

        public CultureMiddleware(IOptions<WikipediaSettings> wikipediaSettings)
        {
            _wikipediaSettings = wikipediaSettings.Value;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var lang = _wikipediaSettings.Language switch
            {
                Language.Russian => "ru-RU",
                Language.English => "en-US"
            };

            var culture = new CultureInfo(lang);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            return next(context);
        }
    }
}
