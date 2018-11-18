namespace Lockethot.Engines.Brack
{
    public interface IScopeList
    {
        int ScopeCount { get; }
        void AddScope();
        void RemoveScope();
    }
}
