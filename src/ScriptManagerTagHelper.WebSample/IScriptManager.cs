using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ScriptManagerTagHelper.WebSample
{
    public interface IScriptManager
    {
        void AddScript(ScriptReference script);

        IEnumerable<ScriptReference> Scripts { get; }
        IEnumerable<string> ScriptTexts { get; }
        void AddScriptText(string scriptTextExecute);
    }
}
