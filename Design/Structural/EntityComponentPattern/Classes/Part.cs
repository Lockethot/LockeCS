namespace Lockethot.Design.Structural.EntityComponentPattern
{
    public abstract class Part
    {
        public Entity Parent { get; protected internal set; }
    }
}
