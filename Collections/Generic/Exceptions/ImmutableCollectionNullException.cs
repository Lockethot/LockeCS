using System;

namespace Lockethot.Collections.Generic
{
    public class ImmutableCollectionNullException : NullReferenceException
    {
        public ImmutableCollectionNullException(Type type) : base("Attempted to access an IImmutableCollection for type " + type.ToString() + " with a null collection value.") { }
    }
}
