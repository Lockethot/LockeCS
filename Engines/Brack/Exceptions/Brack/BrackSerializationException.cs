namespace Lockethot.Engines.Brack
{
    public class BrackSerializationException : BrackException
    {
        public BrackSerializationException(string fileName = null) : this("A Brack Serialization Exception has occured!", fileName) { }
        public BrackSerializationException(string message, string fileName = null) : base("SERIAL: " + message, fileName) { }
    }
}
