using System;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ScriptManagerTagHelper.WebSample;

namespace TagHelpersLocal.Web.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("YouTubeEmbed")]
    public class YouTubeEmbedTagHelper : TagHelper
    {
        private readonly IScriptManager _scriptManager;

        //private static string UniquePageClassName = "z93ec171-0c0f-4a6e-9629-2b24a9e5b502";

        public YouTubeEmbedTagHelper(IScriptManager scriptManager)
        {
            _scriptManager = scriptManager;
        }

        public string Src { get; set; }

        public string YouTubeId { get; set; }

        public string FrameWidth { get; set; } = "480";


        public string FrameHeight { get; set; } = "360";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //class="nsyte" id="6Fg3Aj9GzNw" data-width="480" data-height="360">
            output.TagName = "";

            _scriptManager.AddScript(new ScriptReference("/js/jquery.nonSuckyYouTubeEmbed.js", 1000));

            var uniqueVal = Guid.NewGuid().ToString("D");

            // add guid to .nyste (same for all, global guid)
            var sb = new StringBuilder();
            sb.AppendFormat
            ("<div  id=\"nsyte-{0}\" youtubeid=\"{1}\"    width=\"{2}\" height=\"{3}\"></div>",
                uniqueVal, YouTubeId, FrameWidth, FrameHeight);


            var scriptTextExecute = string.Format(@"
                 $(document).ready(function () {{
                        $('#nsyte-{0}').nonSuckyYouTubeEmbed();
                }});
            ", uniqueVal);
            _scriptManager.AddScriptText(scriptTextExecute);

            output.Content = output.Content.SetHtmlContent(sb.ToString());
        }
    }
}