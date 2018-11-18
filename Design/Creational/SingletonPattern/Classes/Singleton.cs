namespace Lockethot.Design.Creational.SingletonPattern
{
    public abstract class Singleton
    {
        protected Singleton()
        {
            Singletons.SetInstance(this);
        }
    }
}
