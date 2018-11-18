namespace Lockethot.Engines.Brack
{
    public class BrackFileNotFoundException : BrackSerializationException
    {
        public BrackFileNotFoundException(string fileName = null) : base("FILN: File of the given name was not found!", fileName) { }
    }
}
