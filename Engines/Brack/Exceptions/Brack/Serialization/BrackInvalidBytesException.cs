namespace Lockethot.Engines.Brack
{
    public class BrackInvalidBytesException : BrackSerializationException
    {
        public BrackInvalidBytesException(string fileName = null) : base("BYTE: The bytes of the file could not be deserialized to object[][]!", fileName) { }
    }
}
