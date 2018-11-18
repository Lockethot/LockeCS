namespace Lockethot.Engines.Brack
{
    public class BrackSyntaxException : BrackException
    {
        public int Line { get; private set; }
        public int Position { get; private set; }

        public BrackSyntaxException(string fileName = null, int line = -1, int position = -1) : this("A Brack Syntax error has occured!", fileName, line, position) { }
        public BrackSyntaxException(string message, string fileName = null, int line = -1, int position = -1) : base("SYNTAX<" + line.ToString() + "," + position.ToString() + ">: " + message, fileName)
        {
            Line = line;
            Position = position;
        }
    }
}
