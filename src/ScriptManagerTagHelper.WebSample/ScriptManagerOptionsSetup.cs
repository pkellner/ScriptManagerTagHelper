using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace ScriptManagerTagHelper.WebSample
{
    public class ScriptManagerOptionsSetup : IConfigureOptions<ScriptManagerOptions>
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ScriptManagerOptionsSetup(IHostingEnvironment hostingEnv)
        {
            _hostingEnvironment = hostingEnv;
        }

        public void Configure(ScriptManagerOptions options)
        {
            if (_hostingEnvironment.IsProduction())
            {
                options.Minimized = true;
                options.Cdn = "foo.cdn.com";
                options.CombinedSrc = true;
            }
        }
    }

    
}
