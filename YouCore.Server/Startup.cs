//////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Starter kit
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using YouCore.Server.Application;
using YouCore.Server.Common;

namespace YouCore.Server
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("StarterKitSettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add option services  
            services.AddOptions();
            services.Configure<GlobalConfig>(Configuration.GetSection("Globals"));

            // Add MVC services
            services.AddMvc();

            // Add custom application services
            services.AddSingleton<HomeService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
            }
            else
            {
                app.UseExceptionHandler("~/Home/Error");
                app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
