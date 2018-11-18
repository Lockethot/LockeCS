using System;
using System.Collections.Generic;

namespace Lockethot.Engines.Brack
{
    public class BrackRuntimeData
    {
        private OperatorDictionary _OperatorDictionary = new OperatorDictionary();

        private BrackGlobalMemory _GlobalMemory = new BrackGlobalMemory();

        private Stack<BrackLocalMemory> _LocalMemory = new Stack<BrackLocalMemory>();

        public int OpCount => _OperatorDictionary.OpCount;

        public string[] OpNames => _OperatorDictionary.OpNames;

        public int GlobalVarCount => _GlobalMemory.GlobalVarCount;

        public string[] GlobalVarNames => _GlobalMemory.GlobalVarNames;

        public int LocalVarCount => _LocalMemory.Peek().LocalVarCount;

        public string[] LocalVarNames => _LocalMemory.Peek().LocalVarNames;

        public int ScriptCount => _GlobalMemory.ScriptCount;

        public string[] ScriptNames => _GlobalMemory.ScriptNames;

        public int ScopeCount => _LocalMemory.Peek().ScopeCount;

        public int LocalMemoryCount => _LocalMemory.Count;

        public void AddLocalMemory()
        {
            _LocalMemory.Push(new BrackLocalMemory());
        }

        public void AddOp(BrackOperatorBase operation)
        {
            _OperatorDictionary.AddOp(operation);
        }

        public void AddScope()
        {
            _LocalMemory.Peek().AddScope();
        }

        public void AddScript(string scriptName, object[][] statements, string[] arguments, BrackPositionData bpd = null)
        {
            _GlobalMemory.AddScript(scriptName, statements, arguments, bpd);
        }

        public void DeleteGlobalVar(string varName, BrackPositionData bpd = null)
        {
            _GlobalMemory.DeleteGlobalVar(varName, bpd);
        }

        public void DeleteLocalVar(string varName, BrackPositionData bpd = null)
        {
            _LocalMemory.Peek().DeleteLocalVar(varName, bpd);
        }

        public object ExecuteOperator(object[] statement, BrackPositionData bpd)
        {
            return _OperatorDictionary.ExecuteOperator(this, statement, bpd);
        }

        public object ExecuteOperator(string name, object[] arguments, BrackPositionData bpd)
        {
            return _OperatorDictionary.ExecuteOperator(this, name, arguments, bpd);
        }

        public object ExecuteScript(string scriptName, object[] arguments, BrackPositionData bpd = null)
        {
            return _GlobalMemory.ExecuteScript(this, scriptName, arguments, bpd);
        }

        public int GetArgCount(string opName, BrackPositionData bpd = null)
        {
            return _OperatorDictionary.GetArgCount(opName, bpd);
        }

        public Delegate GetDelegate(string opName, BrackPositionData bpd = null)
        {
            return _OperatorDictionary.GetDelegate(opName, bpd);
        }

        public object GetGlobalVar(string varName, BrackPositionData bpd = null)
        {
            return _GlobalMemory.GetGlobalVar(varName, bpd);
        }

        public object GetLocalVar(string varName, BrackPositionData bpd = null)
        {
            return _LocalMemory.Peek().GetLocalVar(varName, bpd);
        }

        public Type[] GetTypes(string opName, BrackPositionData bpd = null)
        {
            return _OperatorDictionary.GetTypes(opName, bpd);
        }

        public bool HasGlobalVar(string varName)
        {
            return _GlobalMemory.HasGlobalVar(varName);
        }

        public bool HasLocalVar(string varName)
        {
            return _LocalMemory.Peek().HasLocalVar(varName);
        }

        public bool HasOp(string name)
        {
            return _OperatorDictionary.HasOp(name);
        }

        public void RemoveLocalMemory()
        {
            _LocalMemory.Pop();
        }

        public void RemoveOp(string opName)
        {
            _OperatorDictionary.RemoveOp(opName);
        }

        public void RemoveScope()
        {
            _LocalMemory.Peek().RemoveScope();
        }

        public void RemoveScript(string scriptName, BrackPositionData bpd = null)
        {
            _GlobalMemory.RemoveScript(scriptName, bpd);
        }

        public void SetGlobalVar(string varName, object value)
        {
            _GlobalMemory.SetGlobalVar(varName, value);
        }

        public void SetLocalVar(string varName, object value)
        {
            _LocalMemory.Peek().SetLocalVar(varName, value);
        }
    }
}
