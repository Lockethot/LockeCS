namespace Lockethot.Collections.Generic
{
    public interface IImmutableCollection
    {
        bool IsNull { get; }
        object DataClone();
    }
}
