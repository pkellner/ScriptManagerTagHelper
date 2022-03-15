using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ScriptManagerTagHelper.WebSample.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("script", Attributes = "src")]
    public class ScriptTagHelper : TagHelper
    {
        private readonly IScriptManager _scriptManager;

        public ScriptTagHelper(IScriptManager scriptManager)
        {
            _scriptManager = scriptManager;
        }

        public string IncludeOrderPriority { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // needed because of builtin tag helper that looks at src
            var src = output.Attributes["src"].Value.ToString();
            foreach (TagHelperAttribute attribute in output.Attributes) {
                if (attribute.Name == "src") continue;
                scriptReference.ScriptReferenceAttributes.Add(
                    new ScriptReferenceAttribute {
                        Name = attribute.Name,
                        Value = GetEncodedStringValue(output.Attributes[attribute.Name].Value)
                    });
            }
            _scriptManager.AddScript(scriptReference);

            await output.GetChildContentAsync();
            output.SuppressOutput();
        }
    }
}