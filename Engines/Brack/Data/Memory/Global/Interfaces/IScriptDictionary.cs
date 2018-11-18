namespace Lockethot.Engines.Brack
{
    public interface IScriptDictionary
    {
        int ScriptCount { get; }
        string[] ScriptNames { get; }
        void AddScript(string scriptName, object[][] statements, string[] arguments, BrackPositionData bpd);
        void RemoveScript(string scriptName, BrackPositionData bpd = null);
        object ExecuteScript(BrackRuntimeData brd, string scriptName, object[] arguments, BrackPositionData bpd);
    }
}
