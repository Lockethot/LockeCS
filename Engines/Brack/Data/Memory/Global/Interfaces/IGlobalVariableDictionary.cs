namespace Lockethot.Engines.Brack
{
    public interface IGlobalVariableDictionary
    {
        int GlobalVarCount { get; }
        string[] GlobalVarNames { get; }
        bool HasGlobalVar(string varName);
        object GetGlobalVar(string varName, BrackPositionData bpd);
        void SetGlobalVar(string varName, object value);
        void DeleteGlobalVar(string varName, BrackPositionData bpd);
    }
}
