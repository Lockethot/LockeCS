namespace Lockethot.Engines.Brack
{
    public class BrackGlobalVariableUndeclaredException : BrackGlobalMemoryException
    {
        public string VarName { get; private set; }
        public BrackGlobalVariableUndeclaredException(string varName = null, string fileName = null, int[] statementID = null) : base("VAR<" + (varName ?? "") + ">: Global variable undeclared!", fileName, statementID)
        {
            VarName = varName;
        }
    }
}
