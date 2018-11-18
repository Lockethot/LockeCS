using Lockethot.Collections.Extensions;
using System.Collections.Generic;

namespace Lockethot.Engines.Brack
{
    public class BrackScope : ILocalVariableDictionary
    {
        private Dictionary<string, object> _LocalVars = new Dictionary<string, object>();

        public int LocalVarCount => _LocalVars.Count;

        public string[] LocalVarNames => _LocalVars.KeyArray();

        public void DeleteLocalVar(string varName, BrackPositionData bpd)
        {
            try
            {
                _LocalVars.Remove(varName);
            }
            catch (KeyNotFoundException)
            {
                if (bpd == null) throw new BrackLocalVariableUndeclaredException(varName);
                else throw new BrackLocalVariableUndeclaredException(varName, bpd.MemoryLevel, -1, bpd.FileName, bpd.StatementID);
            }
        }

        public object GetLocalVar(string varName, BrackPositionData bpd)
        {
            try
            {
                return _LocalVars[varName];
            }
            catch (KeyNotFoundException)
            {
                if (bpd == null) throw new BrackLocalVariableUndeclaredException(varName);
                else throw new BrackLocalVariableUndeclaredException(varName, bpd.MemoryLevel, -1, bpd.FileName, bpd.StatementID);
            }
        }

        public bool HasLocalVar(string varName)
        {
            return _LocalVars.ContainsKey(varName);
        }

        public void SetLocalVar(string varName, object value)
        {
            _LocalVars[varName] = value;
        }
    }
}
