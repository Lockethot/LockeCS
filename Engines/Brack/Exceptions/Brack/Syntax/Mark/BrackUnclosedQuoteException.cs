namespace Lockethot.Engines.Brack
{
    public class BrackUnclosedQuoteException : BrackMarkException
    {
        public BrackUnclosedQuoteException(string fileName = null, int line = -1, int position = -1) : base("QUOT: Quoted string unclosed in Brack file!", fileName, line, position) { }
    }
}
