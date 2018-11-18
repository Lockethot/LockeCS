using Lockethot.Collections.Extensions;
using System.Collections.Generic;

namespace Lockethot.Engines.Brack
{
    public class BrackScriptSet : IScriptDictionary
    {
        private Dictionary<string, BrackScript> _Scripts = new Dictionary<string, BrackScript>();

        public int ScriptCount => _Scripts.Count;

        public string[] ScriptNames => _Scripts.KeyArray();

        public void AddScript(string scriptName, object[][] statements, string[] arguments, BrackPositionData bpd = null)
        {
            _Scripts[scriptName] = new BrackScript(scriptName, bpd.FileName, bpd.StatementID, statements, arguments, bpd);
        }

        public object ExecuteScript(BrackRuntimeData brd, string scriptName, object[] arguments, BrackPositionData bpd = null)
        {
            try
            {
                return _Scripts[scriptName].ExecuteScript(brd, arguments, bpd);
            }
            catch(KeyNotFoundException)
            {
                if (bpd == null) throw new BrackScriptUndeclaredException(scriptName);
                else throw new BrackScriptUndeclaredException(scriptName, bpd.FileName, bpd.StatementID);
            }
        }

        public void RemoveScript(string scriptName, BrackPositionData bpd = null)
        {
            try
            {
                _Scripts.Remove(scriptName);
            }
            catch(KeyNotFoundException)
            {
                if (bpd == null) throw new BrackScriptUndeclaredException(scriptName);
                else throw new BrackScriptUndeclaredException(scriptName, bpd.FileName, bpd.StatementID);
            }
        }
    }
}
