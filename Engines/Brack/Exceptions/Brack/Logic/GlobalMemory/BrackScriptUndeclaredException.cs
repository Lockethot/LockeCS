namespace Lockethot.Engines.Brack
{
    public class BrackScriptUndeclaredException : BrackGlobalMemoryException
    {
        public BrackScriptUndeclaredException(string scriptName = null, string fileName = null, int[] statementID = null) : base("SCUND<" + (scriptName ?? "") + ">: Script name undeclared!", fileName, statementID) { }
    }
}
