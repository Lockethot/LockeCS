using System;

namespace Lockethot.Design.Behavioral.InterpreterPattern
{
    public class InterpreterSyntaxException : InvalidOperationException
    {
        public InterpreterSyntaxException() : base("A syntax error has occured during interpretation.") { }
    }
}
