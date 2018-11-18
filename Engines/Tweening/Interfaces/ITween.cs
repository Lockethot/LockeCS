namespace Lockethot.Engines.Tweening
{
    public interface ITween
    {
        #region Immutable Properties
        float CurrentTime { get; }
        float TotalTime { get; }
        bool IsRunning { get; }
        bool IsPaused { get; }
        #endregion

        #region Event Methods
        ITween Start();
        ITween Step(float deltaTime);
        ITween Finish();
        ITween Pause();
        ITween Continue();
        ITween Reset();
        #endregion
    }
}
