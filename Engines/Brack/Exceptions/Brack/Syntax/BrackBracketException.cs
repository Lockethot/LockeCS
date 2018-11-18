namespace Lockethot.Engines.Brack
{
    public class BrackBracketException : BrackSyntaxException
    {
        public BrackBracketException(string fileName = null, int line = -1, int position = -1) : this("A Brack bracket error has occured!", fileName, line, position) { }
        public BrackBracketException(string message, string fileName = null, int line = -1, int position = -1) : base("BRACKET: " + message, fileName, line, position) { }
    }
}
