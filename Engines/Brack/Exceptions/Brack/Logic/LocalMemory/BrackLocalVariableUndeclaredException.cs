namespace Lockethot.Engines.Brack
{
    public class BrackLocalVariableUndeclaredException : BrackLocalMemoryException
    {
        public string VarName { get; private set; }
        public BrackLocalVariableUndeclaredException(string varName = null, int memoryLevel = -1, int scopeLevel = -1, string fileName = null, int[] statementID = null) : base("VAR<" + (varName ?? "") + ">: Local variable undeclared!", memoryLevel, scopeLevel, fileName, statementID)
        {
            VarName = varName;
        }
    }
}
