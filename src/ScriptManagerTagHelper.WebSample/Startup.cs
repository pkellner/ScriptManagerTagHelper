using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ScriptManagerTagHelper.WebSample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

           


            //////////////// start (not needed)
            services.AddScoped<IScriptManager,ScriptManager>(); // lifetime of http request
            services.AddTransient<ScriptManagerOptionsSetup>();


            // others can add other configurations
            // config is in class so that we have access environment
            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IConfigureOptions<ScriptManagerOptions>,
                    ScriptManagerOptionsSetup>());
            //////////////////////// end
            
            
             


            ////////  either of next two (not both)
            // simple way
            services.AddScriptManager(
                options => options.Minimized = false);


            // simple way takes default options
            services.AddScriptManager();









            //services.AddTransient<ScriptManagerOptions>(new ScriptManagerOptions()
            //{
            //    Minimized = false
            //});


            //services.AddSingleton<ScriptManagerOptions>(new ScriptManagerOptions()
            //{
            //    Minimized = false
            //});







            //services.ScriptManagerOptionsSetup(scriptManagerOptions->
            //{
            //    scriptManagerOptions.Minimized = true,
            //    scriptManagerOptions.CDN = "cloudfront.com",
            //    scriptManagerOptions.CombinedJavaScript = true
            //}
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
           // env.WebRootFileProvider


            app.UseMiddleware<MyMiddleware>();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
