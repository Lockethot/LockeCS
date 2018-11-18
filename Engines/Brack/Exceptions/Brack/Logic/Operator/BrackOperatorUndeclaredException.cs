namespace Lockethot.Engines.Brack
{
    public class BrackOperatorUndeclaredException : BrackOperatorException
    {
        public BrackOperatorUndeclaredException(string opName = null, string fileName = null, int[] statementID = null) : base("DEC: An Operator Undeclared error has occured!", opName, fileName, statementID) { }
    }
}
