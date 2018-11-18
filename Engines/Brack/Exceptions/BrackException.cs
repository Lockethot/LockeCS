using System;

namespace Lockethot.Engines.Brack
{
    public class BrackException : Exception
    {
        public string FileName { get; private set; }

        public BrackException(string fileName = null) : this("A Brack error has occured!", fileName) { }
        public BrackException(string message, string fileName = null) : base((fileName ?? "NA") +  ": " + message)
        {
            FileName = fileName;
        }
    }
}
