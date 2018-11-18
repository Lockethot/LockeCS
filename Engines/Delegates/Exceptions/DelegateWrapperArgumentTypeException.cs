using System;

namespace Lockethot.Engines.Delegates
{
    class DelegateWrapperArgumentTypeException : DelegateWrapperArgumentException
    {
        public DelegateWrapperArgumentTypeException() : base("Argument passed into DelegateWrapper is of invalid type.")
        {
        }
    }
}
