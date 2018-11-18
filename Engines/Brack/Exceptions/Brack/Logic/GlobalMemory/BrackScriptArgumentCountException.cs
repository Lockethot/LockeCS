namespace Lockethot.Engines.Brack
{
    public class BrackScriptArgumentCountException : BrackGlobalMemoryException
    {
        public BrackScriptArgumentCountException(string scriptName = null, int wanted = -1, int found = -1, string fileName = null, int[] statementID = null) : base("SARG<" + (scriptName ?? "") + "," + wanted.ToString() + "," + found.ToString() + ">: Invalid argument count passed into script!", fileName, statementID) { }
    }
}
