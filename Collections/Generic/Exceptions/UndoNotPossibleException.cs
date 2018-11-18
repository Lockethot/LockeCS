using System;

namespace Lockethot.Collections.Generic
{
    public class UndoNotPossibleException : InvalidOperationException
    {
        public UndoNotPossibleException() : base("An Undo action is not possible because there are no remaining actions in the Undo list of the ReversableStack.") { }
    }
}
