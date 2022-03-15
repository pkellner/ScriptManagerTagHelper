using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;

namespace ScriptManagerTagHelper.WebSample.TagHelpers
{
    public class BodyTagHelper : TagHelper
    {
        private readonly IScriptManager _scriptManager;
        private readonly IOptions<ScriptManagerOptions> _scriptManagerOptions;

        public BodyTagHelper(IScriptManager scriptManager,
            IOptions<ScriptManagerOptions> scriptManagerOptions)
        {
            _scriptManager = scriptManager;
            _scriptManagerOptions = scriptManagerOptions;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (await output.GetChildContentAsync()).GetContent();

            var sb = new StringBuilder();
            if (_scriptManager.Scripts.Count > 0)
            {
                foreach (var scriptRef in _scriptManager.Scripts.OrderBy(a => a.IncludeOrderPriorty)) {
                    sb.Append($"<script src='{scriptRef.ScriptPath}'");
                    foreach (var attr in scriptRef.ScriptReferenceAttributes) {
                        sb.Append($" {attr.Name}='{attr.Value}'");
                    }
                    sb.AppendLine("></script>");
                }
                sb.AppendLine("<script type='text/javascript'>");
                foreach (var scriptText in _scriptManager.ScriptTexts)
                    sb.AppendLine(scriptText);
                sb.AppendLine("</script>");
            }
            output.PostContent.AppendHtml(sb.ToString());
        }
    }
}