using System;
using System.Collections.Generic;

namespace Lockethot.Design.Behavioral.InterpreterPattern
{
    public abstract class StringInterpreter<T, T2> : Interpreter<string, T>
    {
        #region Constructors
        protected StringInterpreter() { }
        #endregion

        #region Public Overridable Methods
        public abstract void InterpretChar(string raw, int index, ref T2 data, ref T result);
        #endregion
    }
}
