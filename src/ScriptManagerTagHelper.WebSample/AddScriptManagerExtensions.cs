using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace ScriptManagerTagHelper.WebSample
{
    public static class AddScriptManagerExtensions
    {
        public static IServiceCollection AddScriptManager(this IServiceCollection services,
            Action<ScriptManagerOptions> setupAction)
        {

            //services.AddScoped<IScriptManager, ScriptManager>(); // lifetime of http request (NOT SURE WHY THIS IS NOT ENOUGH)
            //services.AddSingleton<IScriptManager, ScriptManager>(); 

            // others can add other configurations
            // config is in class so that we have access environment
            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IConfigureOptions<ScriptManagerOptions>,
                    ScriptManagerOptionsSetup>());

            services.Configure(setupAction);

            return services;
        }

        public static IServiceCollection AddScriptManager(this IServiceCollection services)
        {

            // passes in empty setup method
            AddScriptManager(services, a => {});

            return services;
        }

    }
}
