
namespace Lockethot.Engines.Brack
{
    public class BrackNotMatchingBracketException : BrackBracketException
    {
        public BrackNotMatchingBracketException(string fileName = null, int line = -1, int position = -1) : this(BracketType.NA, BracketType.NA, fileName, line, position) { }
        public BrackNotMatchingBracketException(BracketType openType, BracketType closeType, string fileName = null, int line = -1, int position = -1) : base("MATCH: Bracket of type " + openType.ToString() + " closed with bracket of unmatching type " + closeType.ToString() + "!", fileName, line, position) { }
    }
}
