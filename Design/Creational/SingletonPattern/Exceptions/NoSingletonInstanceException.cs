using System;

namespace Lockethot.Design.Creational.SingletonPattern
{
    public class NoSingletonInstanceException : InvalidOperationException
    {
        public NoSingletonInstanceException(Type type) : base("No Singleton instance found for type " + type.ToString() + ".") { }
    }
}
