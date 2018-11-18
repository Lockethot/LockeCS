using System;

namespace Lockethot.Design.Creational.SingletonPattern
{
    public class MultipleSingletonInstancesException : InvalidOperationException
    {
        public MultipleSingletonInstancesException(Type type) : base("You cannot instantiate more than one of Singleton type " + type.ToString() + ".") { }
    }
}
