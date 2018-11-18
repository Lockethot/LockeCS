namespace Lockethot.Engines.Brack
{
    public class BrackLocalMemoryException : BrackLogicException
    {
        public int MemoryLevel { get; private set; }
        public int ScopeLevel { get; private set; }
        public BrackLocalMemoryException(int memoryLevel = -1, int scopeLevel = -1, string fileName = null, int[] statementID = null) : this("A Brack LocalMemory error has occured!", memoryLevel, scopeLevel, fileName, statementID) { }
        public BrackLocalMemoryException(string message, int scopeLevel = -1, int memoryLevel = -1, string fileName = null, int[] statementID = null) : base("LM<" + memoryLevel.ToString() + "," + scopeLevel.ToString() + ">: " + message, fileName, statementID)
        {
            ScopeLevel = scopeLevel;
            MemoryLevel = memoryLevel;
        }
    }
}
