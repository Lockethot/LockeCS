using System;

namespace Lockethot.Design.Structural.EntityComponentPattern
{
    public class ComponentDuplicateException : InvalidOperationException
    {
        public ComponentDuplicateException() : base("The same component added twice to same entity.") { }
    }
}
