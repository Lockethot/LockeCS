namespace Lockethot.Engines.Brack
{
    public class BrackUnclosedBracketException : BrackBracketException
    {
        public BrackUnclosedBracketException(string fileName = null, int line = -1, int position = -1) : this(BracketType.NA, fileName, line, position) { }
        public BrackUnclosedBracketException(BracketType unclosedType, string fileName = null, int line = -1, int position = -1) : base("UNCLOSE: Bracket of type " + unclosedType.ToString() + " is not closed by the end of file!", fileName, line, position) { }
    }
}
