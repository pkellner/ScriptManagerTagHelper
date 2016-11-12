using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ScriptManagerTagHelper.WebSample.TagHelpers
{
        [HtmlTargetElement("Email")]
        public class EmailTagHelper : TagHelper
        {
            private const string EmailDomain = "contoso.com";

            // Can be passed via <email mail-to="..." />. 
            // Pascal case gets translated into lower-kebab-case.
            public string MailTo { get; set; }

            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                var mailToWorks = output.Attributes["MailTo"].Value.ToString();

                output.TagName = "a";    // Replaces <email> with <a> tag

                var address = MailTo + "@" + EmailDomain;
                output.Attributes.SetAttribute("href", "mailto:" + address);
                output.Content.SetContent(address);
            }
        }
}
