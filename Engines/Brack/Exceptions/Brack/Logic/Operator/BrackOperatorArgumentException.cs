namespace Lockethot.Engines.Brack
{
    public class BrackOperatorArgumentException : BrackOperatorException
    {
        public int ArgumentIndex { get; private set; }
        public BrackOperatorArgumentException(string message, int argumentIndex = -1, string opName = null, string fileName = null, int[] statementID = null) : base("ARG<" + argumentIndex.ToString() + ">: " + message, opName, fileName, statementID) { }
        public BrackOperatorArgumentException(int argumentIndex = -1, string opName = null, string fileName = null, int[] statementID = null) : base("ARG<" + argumentIndex.ToString() + ">: An Operator Argument error has occured!", opName, fileName, statementID)
        {
            ArgumentIndex = argumentIndex;
        }
    }
}
