namespace Lockethot.Engines.Tweening
{
    public class SimpleDelegateTween : ITween
    {
        #region Private Properties
        private TweenStageDelegate _Step;
        private ITween _ProceedingTween;
        #endregion

        #region Immutable ITween Properties
        public float CurrentTime { get; private set; }
        public float TotalTime { get; private set; }
        public bool IsRunning { get; private set; }
        public bool IsPaused { get; private set; }
        #endregion

        #region Constructors
        public SimpleDelegateTween(float totalTime, TweenStageDelegate step)
        {
            Reset();
            SetTotalTime(totalTime);
            SetStep(step);
        }
        #endregion

        #region Public Chainable Methods
        public SimpleDelegateTween SetTotalTime(float totalTime)
        {
            if (totalTime < 0f)
            {
                throw new TotalTimeInvalidException();
            }
            TotalTime = totalTime;
            return this;
        }

        public SimpleDelegateTween SetStep(TweenStageDelegate step)
        {
            _Step = step ?? throw new TweenStepNullException();
            return this;
        }

        public SimpleDelegateTween SetProceedingTween(ITween proceedingTween)
        {
            _ProceedingTween = proceedingTween;
            return this;
        }
        #endregion

        #region ITween Public Chainable Methods
        public ITween Start()
        {
            ShouldNotBeRunningExceptionCheck();
            IsRunning = true;
            _Step(0, TotalTime);
            return this;
        }

        public ITween Step(float deltaTime)
        {
            ShouldBeRunningExceptionCheck();
            CurrentTime += deltaTime;
            if (CurrentTime >= TotalTime) Finish(); else _Step(CurrentTime, TotalTime);
            return this;
        }

        public ITween Finish()
        {
            ShouldBeRunningExceptionCheck();
            CurrentTime = TotalTime;
            _Step(CurrentTime, TotalTime);
            IsRunning = false;
            if (!_ProceedingTween.IsRunning) _ProceedingTween.Start();
            return this;
        }

        public ITween Pause()
        {
            ShouldBeRunningExceptionCheck();
            ShouldNotBePausedExceptionCheck();
            _Step(CurrentTime, TotalTime);
            IsPaused = true;
            return this;
        }

        public ITween Continue()
        {
            ShouldBeRunningExceptionCheck();
            ShouldBePausedExceptionCheck();
            _Step(CurrentTime, TotalTime);
            IsPaused = false;
            return this;
        }

        public ITween Reset()
        {
            _Step(CurrentTime, TotalTime);
            IsRunning = false;
            IsPaused = false;
            CurrentTime = 0f;
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
