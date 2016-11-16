using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;

namespace ScriptManagerTagHelper.WebSample.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project


    public class BodyTagHelper : TagHelper
    {
        public override int Order => int.MaxValue - 100;


        private readonly IScriptManager _scriptManager;
        private readonly IOptions<ScriptManagerOptions> _scriptManagerOptions;
        private readonly IHostingEnvironment _hostingEnvironment;




        public BodyTagHelper(IScriptManager scriptManager,
            IOptions<ScriptManagerOptions> scriptManagerOptions,
            IHostingEnvironment hostingEnvironment)
        {
            _scriptManager = scriptManager;
            _scriptManagerOptions = scriptManagerOptions;
            _hostingEnvironment = hostingEnvironment;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (await output.GetChildContentAsync()).GetContent();

            StringBuilder sb = new StringBuilder();
            if (_scriptManager.Scripts.Count > 0)
            {
                foreach (var scriptRef in _scriptManager.Scripts.OrderBy(a => a.IncludeOrderPriorty))
                {
                    sb.AppendLine(string.Format("<script src='{0}' ></script>", scriptRef.ScriptPath));
                }
                sb.AppendLine("<script type='text/javascript'>");
                foreach (var scriptText in _scriptManager.ScriptTexts)
                {
                    sb.AppendLine(scriptText);
                }
                sb.AppendLine("</script>");
            }
            output.PostContent.AppendHtml(sb.ToString());
        }
    }
}
