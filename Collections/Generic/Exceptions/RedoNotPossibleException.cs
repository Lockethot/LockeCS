using System;

namespace Lockethot.Collections.Generic
{
    public class RedoNotPossibleException : InvalidOperationException
    {
        public RedoNotPossibleException() : base("A Redo action is not possible because there are no remaining actions in the Redo list of the ReversableStack.") { }
    }
}
