namespace Lockethot.Engines.Tweening
{
    public class DelayedStartTween : ITween
    {
        #region Private Properties
        private ITween _ProceedingTween;
        #endregion

        #region Immutable Properties
        public float CurrentTime { get; private set; }
        public float TotalTime { get; private set; }
        public bool IsRunning { get; private set; }
        public bool IsPaused { get; private set; }
        #endregion

        #region Constructors
        public DelayedStartTween(float totalTime, ITween proceedingTween)
        {
            SetTotalTime(totalTime);
            _ProceedingTween = proceedingTween;
            Reset();
        }
        #endregion

        #region Public Chainable Methods
        public DelayedStartTween SetTotalTime(float totalTime)
        {
            if (totalTime < 0f)
            {
                throw new TotalTimeInvalidException();
            }
            TotalTime = totalTime;
            return this;
        }

        public DelayedStartTween SetProceedingTween(ITween proceedingTween)
        {
            _ProceedingTween = proceedingTween;
            return this;
        }
        #endregion

        #region ITween Implemntation Methods
        public ITween Start()
        {
            ShouldNotBeRunningExceptionCheck();
            IsRunning = true;
            return this;
        }
        public ITween Step(float deltaTime)
        {
            ShouldBeRunningExceptionCheck();
            CurrentTime += deltaTime;
            if (CurrentTime >= TotalTime)
            {
                Finish();
            }
            return this;
        }
        public ITween Finish()
        {
            ShouldBeRunningExceptionCheck();
            IsRunning = false;
            IsPaused = false;
            CurrentTime = TotalTime;
            _ProceedingTween.Start();
            return this;
        }
        public ITween Pause()
        {
            ShouldBeRunningExceptionCheck();
            ShouldNotBePausedExceptionCheck();
            IsPaused = true;
            return this;
        }
        public ITween Continue()
        {
            ShouldBePausedExceptionCheck();
            IsPaused = false;
            return this;
        }
        public ITween Reset()
        {
            CurrentTime = 0f;
            IsRunning = false;
            IsPaused = false;
            return this;
        }
        #endregion

        #region Private Utility Methods
        private void ShouldBeRunningExceptionCheck()
        {
            if (!IsRunning) throw new TweenNotRunningException();
        }

        private void ShouldNotBeRunningExceptionCheck()
        {
            if (IsRunning) throw new TweenAlreadyRunningException();
        }

        private void ShouldBePausedExceptionCheck()
        {
            if (!IsPaused) throw new TweenNotPausedException();
        }

        private void ShouldNotBePausedExceptionCheck()
        {
            if (IsPaused) throw new TweenAlreadyPausedException();
        }
        #endregion
    }
}
