namespace Lockethot.Engines.Brack
{
    public interface ILocalVariableDictionary
    {
        int LocalVarCount { get; }
        string[] LocalVarNames { get; }
        bool HasLocalVar(string varName);
        object GetLocalVar(string varName, BrackPositionData bpd = null);
        void SetLocalVar(string varName, object value);
        void DeleteLocalVar(string varName, BrackPositionData bpd = null);
    }
}
