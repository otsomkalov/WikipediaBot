using System.Globalization;
using Bot.Middlewares;
using Bot.Services;
using Bot.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using WikipediaNet;

namespace Bot
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TelegramSettings>(_configuration.GetSection(TelegramSettings.SectionName))
                .Configure<WikipediaSettings>(_configuration.GetSection(WikipediaSettings.SectionName));
        
            services
                .AddSingleton<ITelegramBotClient>(provider =>
                {
                    var settings = provider.GetService<IOptions<TelegramSettings>>().Value;
                    
                    return new TelegramBotClient(settings.Token);
                })
                .AddSingleton(provider =>
                {
                    var settings = provider.GetService<IOptions<WikipediaSettings>>().Value;

                    return new Wikipedia(settings.Language);
                })
                .AddScoped<MessageService>()
                .AddScoped<InlineQueryService>();

            services.AddLocalization();
            
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<CultureMiddleware>();
            
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}