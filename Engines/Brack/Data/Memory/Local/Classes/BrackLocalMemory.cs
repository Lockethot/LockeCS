using Lockethot.Collections.Extensions;
using System.Collections.Generic;

namespace Lockethot.Engines.Brack
{
    public class BrackLocalMemory : IScopeList , ILocalVariableDictionary
    {
        private List<BrackScope> _Scopes = new List<BrackScope>();

        public int ScopeCount => _Scopes.Count;

        public int LocalVarCount
        {
            get
            {
                var ret = 0;
                for(var i = 0; i < _Scopes.Count; i ++)
                {
                    ret += _Scopes[i].LocalVarCount;
                }
                return ret;
            }
        }

        public string[] LocalVarNames
        {
            get
            {
                var ret = new List<string>();
                for(var i = 0; i < _Scopes.Count; i ++)
                {
                    ret.AddRange(_Scopes[i].LocalVarNames);
                }
                return ret.ToArray();
            }
        }

        public BrackLocalMemory()
        {
            AddScope();
        }

        public void AddScope()
        {
            _Scopes.Add(new BrackScope());
        }

        public void DeleteLocalVar(string varName, BrackPositionData bpd = null)
        {
            for (var scopeLevel = 0; scopeLevel < _Scopes.Count; scopeLevel ++)
            {
                if (_Scopes[scopeLevel].HasLocalVar(varName))
                {
                    _Scopes[scopeLevel].DeleteLocalVar(varName, bpd);
                }
            }
            if (bpd == null) throw new BrackLocalVariableUndeclaredException(varName);
            else throw new BrackLocalVariableUndeclaredException(varName, bpd.MemoryLevel, -1, bpd.FileName, bpd.StatementID);
        }

        public object GetLocalVar(string varName, BrackPositionData bpd = null)
        {
            for(var scopeLevel = 0; scopeLevel < _Scopes.Count; scopeLevel ++)
            {
                if (_Scopes[scopeLevel].HasLocalVar(varName))
                {
                    return _Scopes[scopeLevel].GetLocalVar(varName, bpd);
                }
            }
            if (bpd == null) throw new BrackLocalVariableUndeclaredException(varName);
            else throw new BrackLocalVariableUndeclaredException(varName, bpd.MemoryLevel, -1, bpd.FileName, bpd.StatementID);
        }

        public bool HasLocalVar(string varName)
        {
            for (var scopeLevel = 0; scopeLevel < _Scopes.Count; scopeLevel++)
            {
                if (_Scopes[scopeLevel].HasLocalVar(varName))
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveScope()
        {
            _Scopes.PopLast();
        }

        public void SetLocalVar(string varName, object value)
        {
            for (var scopeLevel = 0; scopeLevel < _Scopes.Count; scopeLevel++)
            {
                if (_Scopes[scopeLevel].HasLocalVar(varName))
                {
                    _Scopes[scopeLevel].SetLocalVar(varName, value);
                }
            }
            _Scopes.PeekLast().SetLocalVar(varName, value);
        }
    }
}
