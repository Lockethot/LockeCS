namespace Lockethot.Engines.Brack
{
    public class BrackGlobalMemory : IGlobalVariableDictionary, IScriptDictionary
    {
        private BrackGlobalScope _Scope = new BrackGlobalScope();

        private BrackScriptSet _ScriptSet = new BrackScriptSet();

        public int GlobalVarCount => _Scope.GlobalVarCount;

        public string[] GlobalVarNames => _Scope.GlobalVarNames;

        public int ScriptCount => _ScriptSet.ScriptCount;

        public string[] ScriptNames => _ScriptSet.ScriptNames;

        public void AddScript(string scriptName, object[][] statements, string[] arguments, BrackPositionData bpd = null)
        {
            _ScriptSet.AddScript(scriptName, statements, arguments, bpd);
        }

        public void DeleteGlobalVar(string varName, BrackPositionData bpd = null)
        {
            _Scope.DeleteGlobalVar(varName, bpd);
        }

        public object ExecuteScript(BrackRuntimeData brd, string scriptName, object[] arguments, BrackPositionData bpd = null)
        {
            return _ScriptSet.ExecuteScript(brd, scriptName, arguments, bpd);
        }

        public object GetGlobalVar(string varName, BrackPositionData bpd = null)
        {
            return _Scope.GetGlobalVar(varName, bpd);
        }

        public bool HasGlobalVar(string varName)
        {
            return _Scope.HasGlobalVar(varName);
        }

        public void RemoveScript(string scriptName, BrackPositionData bpd = null)
        {
            _ScriptSet.RemoveScript(scriptName, bpd);
        }

        public void SetGlobalVar(string varName, object value)
        {
            _Scope.SetGlobalVar(varName, value);
        }
    }
}
