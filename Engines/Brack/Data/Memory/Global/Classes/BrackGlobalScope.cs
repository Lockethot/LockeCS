using Lockethot.Collections.Extensions;
using System.Collections.Generic;

namespace Lockethot.Engines.Brack
{
    public class BrackGlobalScope : IGlobalVariableDictionary
    {
        private Dictionary<string, object> _GlobalVars = new Dictionary<string, object>();

        public int GlobalVarCount => _GlobalVars.Count;

        public string[] GlobalVarNames => _GlobalVars.KeyArray();

        public void DeleteGlobalVar(string varName, BrackPositionData bpd = null)
        {
            try
            {
                _GlobalVars.Remove(varName);
            }
            catch (KeyNotFoundException)
            {
                if (bpd == null) throw new BrackGlobalVariableUndeclaredException(varName);
                else throw new BrackGlobalVariableUndeclaredException(varName, bpd.FileName, bpd.StatementID);
            }
        }

        public object GetGlobalVar(string varName, BrackPositionData bpd = null)
        {
            try
            {
                return _GlobalVars[varName];
            }
            catch (KeyNotFoundException)
            {
                if (bpd == null) throw new BrackGlobalVariableUndeclaredException(varName);
                else throw new BrackGlobalVariableUndeclaredException(varName, bpd.FileName, bpd.StatementID);
            }
        }

        public bool HasGlobalVar(string varName)
        {
            return _GlobalVars.ContainsKey(varName);
        }

        public void SetGlobalVar(string varName, object value)
        {
            _GlobalVars[varName] = value;
        }
    }
}
