namespace Lockethot.Engines.Brack
{
    public class BrackScriptArgumentNameMatchException : BrackGlobalMemoryException
    {
        public BrackScriptArgumentNameMatchException(string scriptName = null, string matching = null, string fileName = null, int[] statementID = null) : base("SANM<" + (scriptName ?? "") + "," + (matching ?? "") + ">: Two or more arguments of a Script have the same name!", fileName, statementID) { }
    }
}
