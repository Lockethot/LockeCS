using System;

namespace Lockethot.Design.Structural.EntityComponentPattern
{
    public class ComponentNotFoundException : InvalidOperationException
    {
        public ComponentNotFoundException(Type type) : base("Component of type " + type.ToString() + " not found on entity.") { }
    }
}
