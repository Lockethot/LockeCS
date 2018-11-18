using Lockethot.Design.Creational.SingletonPattern;
using System;

namespace Lockethot.Design.Behavioral.InterpreterPattern
{
    public abstract class Interpreter<T1, T2> : Singleton
    {
        #region Constructors
        protected Interpreter() { }
        #endregion

        #region Public Overridable Methods
        public abstract T2 Interperet(T1 raw);
        #endregion
    }
}
