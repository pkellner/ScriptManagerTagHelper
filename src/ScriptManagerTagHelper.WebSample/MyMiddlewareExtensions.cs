using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace ScriptManagerTagHelper.WebSample
{
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware
                    (this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}
