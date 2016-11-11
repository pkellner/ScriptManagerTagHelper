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

        public YouTubeEmbedTagHelper(IScriptManager scriptManager)
        {
            _scriptManager = scriptManager;
        }

        public string Src { get; set; }

        public string YouTubeId  { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //class="nsyte" id="6Fg3Aj9GzNw" data-width="480" data-height="360">
            output.TagName = "";

            var sb = new StringBuilder();
            sb.Append
                ("<div  class=\"nsyte\" id=\"6Fg3Aj9GzNw\" data-width=\"480\" data-height=\"360\"></div>");


            var scriptTextExecute = @"
                 $(document).ready(function () {
                        $('.nsyte').nonSuckyYouTubeEmbed();
                });
            ";

            _scriptManager.AddScriptText(scriptTextExecute);
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