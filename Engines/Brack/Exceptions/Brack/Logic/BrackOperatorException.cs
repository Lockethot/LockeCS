namespace Lockethot.Engines.Brack
{
    public class BrackOperatorException : BrackLogicException
    {
        public string OpName { get; private set; }
        public BrackOperatorException(string fileName = null, int[] statementID = null) : this("A Brack Operator error has occured!", null, fileName, statementID) { }
        public BrackOperatorException(string message, string opName = null, string fileName = null, int[] statementID = null) : base("OP<" + (opName ?? "") + ">: " + message, fileName, statementID)
        {
            OpName = opName;
        }
    }
}
