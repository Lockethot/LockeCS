namespace Lockethot.Engines.Brack
{
    public class BrackMarkException : BrackSyntaxException
    {
        public BrackMarkException(string fileName = null, int line = -1, int position = -1) : this("A Brack mark error has occured!", fileName, line, position) { }
        public BrackMarkException(string message, string fileName = null, int line = -1, int position = -1) : base("MARK: " + message, fileName, line, position) { }
    }
}
