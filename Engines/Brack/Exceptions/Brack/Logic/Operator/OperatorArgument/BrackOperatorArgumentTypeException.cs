using System;

namespace Lockethot.Engines.Brack
{
    public class BrackOperatorArgumentTypeException : BrackOperatorArgumentException
    {
        public BrackOperatorArgumentTypeException(Type wanted = null, Type found = null, int argumentIndex = -1, string opName = null, string fileName = null, int[] statementID = null) : base("TYPE<" + found.ToString() + "," + wanted.ToString() + ": An Operator Argument Type error has occured!", argumentIndex, opName, fileName, statementID) { }
    }
}
