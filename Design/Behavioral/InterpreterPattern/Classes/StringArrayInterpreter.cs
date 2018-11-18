using System;
using System.Collections.Generic;

namespace Lockethot.Design.Behavioral.InterpreterPattern
{
    public abstract class StringArrayInterpreter<T, T2> : Interpreter<string, T[]>
    {
        #region Constructors
        protected StringArrayInterpreter() { }
        #endregion

        #region Public Overridable Methods
        public abstract void InterpretChar(string raw, int index, ref T2 data, List<T> result);
        #endregion

        #region Protected Utility Methods
        protected virtual T[] InterpretLoop(string raw, T2 data)
        {
            var result = new List<T>();
            for(var i = 0; i < raw.Length; i ++)
            {
                InterpretChar(raw, i, ref data, result);
            }
            return result.ToArray();
        }
        #endregion
    }
}