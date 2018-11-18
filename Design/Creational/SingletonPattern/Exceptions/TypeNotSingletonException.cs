using System;

namespace Lockethot.Design.Creational.SingletonPattern
{
    public class TypeNotSingletonException : ArgumentException
    {
        public Type Type { get; protected set; }

        public TypeNotSingletonException(Type type) : base("The Type " + type.ToString() + " is not a Singleton.")
        {
            Type = type;
        }
    }
}
