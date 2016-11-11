using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace ScriptManagerTagHelper.WebSample
{
    public class ScriptManager : IScriptManager
    {
        public IEnumerable<string> Scripts => _scripts;
        public IEnumerable<string> ScriptTexts => _scriptTexts;


       

        // getter only prop retrieves scripts
        // this is the filenames (or URL's) of the script tags
        private readonly List<string> _scripts = new List<string>();

        private readonly List<string> _scriptTexts = new List<string>();

        public void AddScript(string script)
        {
            // dedup scripts
            _scripts.Add(script);
        }

        public void AddScriptText(string scriptTextExecute)
        {
            // dedup with CRC
            _scriptTexts.Add(scriptTextExecute);
        }
    }
}
