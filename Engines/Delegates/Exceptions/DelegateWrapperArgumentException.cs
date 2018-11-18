using System;

namespace Lockethot.Engines.Delegates
{
    class DelegateWrapperArgumentException : ArgumentException
    {
        public DelegateWrapperArgumentException() : base("Invalid arguments array passed into delegate wrapper.") { }
        public DelegateWrapperArgumentException(string message) : base(message) { }
    }
}
