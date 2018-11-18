namespace Lockethot.Engines.Brack
{
    public class BrackInvalidEscapeException : BrackMarkException
    {
        public BrackInvalidEscapeException(string fileName = null, int line = -1, int position = -1) : this(' ', fileName, line, position) { }
        public BrackInvalidEscapeException(char character, string fileName = null, int line = -1, int position = -1) : base("ESCAPE: The character " + character.ToString() + " was escaped and it is not escapable!", fileName, line, position) { }
    }
}
