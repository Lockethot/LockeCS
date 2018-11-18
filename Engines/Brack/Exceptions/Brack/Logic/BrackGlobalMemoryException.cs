namespace Lockethot.Engines.Brack
{
    public class BrackGlobalMemoryException : BrackLogicException
    {
        public BrackGlobalMemoryException(string fileName = null, int[] statementID = null) : this("A Brack GlobalMemory error has occured!", fileName, statementID) { }
        public BrackGlobalMemoryException(string message, string fileName = null, int[] statementID = null) : base("GM: " + message, fileName, statementID) { }
    }
}
