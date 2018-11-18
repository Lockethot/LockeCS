using System;

namespace Lockethot.Design.Structural.EntityComponentPattern
{
    public class DuplicateChildException : InvalidOperationException
    {
        public DuplicateChildException() : base("An entity cannot be added twice as a child to the same entity.") { }
    }
}
