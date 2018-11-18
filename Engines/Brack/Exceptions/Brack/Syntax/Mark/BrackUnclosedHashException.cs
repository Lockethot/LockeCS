namespace Lockethot.Engines.Brack
{
    public class BrackUnclosedHashException : BrackMarkException
    {
        public BrackUnclosedHashException(string fileName = null, int line = -1, int position = -1) : base("HASH: Hash comment unclosed in Brack file!", fileName, line, position) { }
    }
}
