using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
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

        public string YouTubeId  { get; set; }

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
                ("<div  class=\"nsyte-{0}\" id=\"{1}\"    width=\"{2}\" height=\"{3}\"></div>", 
                uniqueVal,YouTubeId,FrameWidth,FrameHeight);

            

            var scriptTextExecute = String.Format(@"
                 $(document).ready(function () {{
                        $('.nsyte-{0}').nonSuckyYouTubeEmbed();
                }});
            ", uniqueVal);
            _scriptManager.AddScriptText(scriptTextExecute);

            sb.AppendLine(" Count: " + _scriptManager.ScriptTexts.Count);
            output.Content = output.Content.SetHtmlContent(sb.ToString());

        }
    }
}


//http://www.jeffreyfritz.com/2014/11/get-started-with-asp-net-mvc-taghelpers/

//    public override void Process(TagHelperContext context, TagHelperOutput output)
//{

//    output.TagName = "";

//    var sb = new StringBuilder();

//    sb.AppendFormat("<input id="\"{0}\"" name = "\"{0}\"" type = "\"text\"" value = "\"{1}\"/" /> ",
//        ID, Value);

//    // Script
//    sb.Append("<script type="text / javascript">// <![CDATA[
// ");     
//    sb.AppendFormat("$(\"#" + ID + "\").kendoDatePicker({{");

//    var firstItem = "";
//    if (!string.IsNullOrEmpty(StartView))
//    {
//        sb.AppendFormat("start: \"{0}\"", StartView);
//        firstItem = ",";
//    }
//    if (!string.IsNullOrEmpty(Depth))
//    {
//        sb.AppendFormat("{1}depth: \"{0}\"", Depth, firstItem);
//        firstItem = ",";
//    }
//    if (!string.IsNullOrEmpty(StartView))
//    {
//        sb.AppendFormat("{1}format: \"{0}\"", Format, firstItem);
//    }

//    sb.Append("});");
//    sb.Append("</script>");
//    output.Content = sb.ToString();
//}