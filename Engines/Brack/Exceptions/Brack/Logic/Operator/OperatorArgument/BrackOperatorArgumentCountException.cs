namespace Lockethot.Engines.Brack
{
    public class BrackOperatorArgumentCountException : BrackOperatorArgumentException
    {
        public BrackOperatorArgumentCountException(int expectedCount = -1, int foundCount = -1, string opName = null, string fileName = null, int[] statementID = null) : base("COUNT<" + expectedCount.ToString() + "," + foundCount.ToString()+  ">: An invalid Operator Argument Count exception has occured!", -1, opName, fileName, statementID) { }
    }
}
