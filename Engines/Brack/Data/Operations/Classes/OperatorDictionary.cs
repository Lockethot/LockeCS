using Lockethot.Collections.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lockethot.Engines.Brack
{
    public class OperatorDictionary : IOperatorDictionary
    {
        private Dictionary<string, BrackOperatorBase> _Operators = new Dictionary<string, BrackOperatorBase>();

        public int OpCount => _Operators.Count;

        public string[] OpNames => _Operators.KeyArray();

        public void AddOp(BrackOperatorBase operation)
        {
            _Operators.Add(operation.OpName, operation);
        }

        public object ExecuteOperator(BrackRuntimeData brd, object[] statement, BrackPositionData bpd)
        {
            return _Operators[statement[0].ToString()].Execute(brd, bpd, statement.Skip(1).ToArray());
        }

        public object ExecuteOperator(BrackRuntimeData brd, string name, object[] arguments, BrackPositionData bpd)
        {
            return _Operators[name].Execute(brd, bpd, arguments);
        }

        public int GetArgCount(string opName, BrackPositionData bpd)
        {
            return _Operators[opName].ArgumentCount;
        }

        public Delegate GetDelegate(string opName, BrackPositionData bpd)
        {
            return _Operators[opName].OperatorDelegate;
        }

        public Type[] GetTypes(string opName, BrackPositionData bpd)
        {
            return _Operators[opName].ArgumentTypes;
        }

        public bool HasOp(string name)
        {
            return _Operators.ContainsKey(name);
        }

        public void RemoveOp(string opName)
        {
            _Operators.Remove(opName);
        }
    }
}
