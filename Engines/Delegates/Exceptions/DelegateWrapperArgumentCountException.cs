using System;

namespace Lockethot.Engines.Delegates
{
    class DelegateWrapperArgumentCountException : DelegateWrapperArgumentException
    {
        public int GivenCount { get; protected set; }
        public int ExpectedCount { get; protected set; }

        public DelegateWrapperArgumentCountException(int given, int expected) : base("The amount of arguments passed in (" + given.ToString() + ") does not match the expected amount of arguments (" + expected.ToString() +").")
        {
            GivenCount = given;
            ExpectedCount = expected;
        }
    }
}
