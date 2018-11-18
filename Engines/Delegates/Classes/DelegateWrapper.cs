using Lockethot.Collections.Generic;
using System;

namespace Lockethot.Engines.Delegates
{
    public class DelegateWrapper
    {
        public int ArgumentCount => ArgumentTypes.Length;
        public bool HasReturn { get; protected set; }
        public Type ReturnType { get; protected set; }
        public ImmutableArray<Type> ArgumentTypes { get; protected set; }

        protected Delegate _Del;

        protected DelegateWrapper() { }

        public DelegateWrapper(Delegate del)
        {
            _Del = del ?? throw new ArgumentNullException("del");
            ReturnType = del.GetReturnType();
            HasReturn = ReturnType != typeof(void);
            ArgumentTypes = new ImmutableArray<Type>(del.GetParameterTypes());
        }

        public virtual object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return _Del.Method.Invoke(_Del, arguments);
            }
            catch (InvalidOperationException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }

        protected void CheckArgumentCount(int count)
        {
            if (count != ArgumentCount)
            {
                throw new DelegateWrapperArgumentCountException(count, ArgumentCount);
            }
        }
    }
}
