using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ScriptManagerTagHelper.WebSample.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("script",Attributes = "src")]
    public class ScriptTagHelper : TagHelper
    {
        private readonly IScriptManager _scriptManager;


        // case insenstative
        // DON'T USE THIS BECAUSE PREVIOUS TAGHELPER RAN ON IT ~ TAG HELPER, MVC SCRIPT TAG HELPER  
        //public string Src { get; set; }

        public ScriptTagHelper(IScriptManager scriptManager)
        {
            _scriptManager = scriptManager;
        }

        public string IncludeOrderPriority { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var src = output.Attributes["src"].Value.ToString(); // get here and not property because other tag helpers might have run
                                                                 // src is going to look /foo/abc.js

            // find file passe in to source


            // add file to script manager (de-duplicate in script manager)

            var xx = output.Attributes["IncludeOrderPriority"].ToString();

            _scriptManager.AddScript(new ScriptReference(src, Convert.ToInt32(IncludeOrderPriority)));

            // suppress output
            output.SuppressOutput();

        }
    }
}
