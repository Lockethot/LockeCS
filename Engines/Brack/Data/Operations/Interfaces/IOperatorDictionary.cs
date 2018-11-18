using System;

namespace Lockethot.Engines.Brack
{
    public interface IOperatorDictionary
    {
        int OpCount { get; }
        string[] OpNames { get; }
        bool HasOp(string name);
        int GetArgCount(string opName, BrackPositionData bpd);
        Type[] GetTypes(string opName, BrackPositionData bpd);
        Delegate GetDelegate(string opName, BrackPositionData bpd);
        void AddOp(BrackOperatorBase operation);
        void RemoveOp(string opName);
        object ExecuteOperator(BrackRuntimeData brd, object[] statement, BrackPositionData bpd);
        object ExecuteOperator(BrackRuntimeData brd, string name, object[] arguments, BrackPositionData bpd);
    }
}
