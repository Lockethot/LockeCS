using System;

namespace Lockethot.Design.Structural.EntityComponentPattern
{
    public class ChildNotFoundException : InvalidOperationException
    {
        public ChildNotFoundException(Type type) : base("Entity of type " + type.ToString() + " not found as child of entity.") { }
    }
}
