namespace Lockethot.Engines.Tweening
{
    public class ComplexDelegateTween : ITween
    {
        #region Private Properties
        private TweenStageDelegate _Start;
        private TweenStageDelegate _Step;
        private TweenStageDelegate _Finish;
        private TweenStageDelegate _Pause;
        private TweenStageDelegate _Continue;
        private TweenStageDelegate _Reset;
        private ITween _ProceedingTween;
        #endregion

        #region Immutable ITween Properties
        public float CurrentTime { get; private set; }
        public float TotalTime { get; private set; }
        public bool IsRunning { get; private set; }
        public bool IsPaused { get; private set; }
        #endregion

        #region Constructors
        public ComplexDelegateTween(float totalTime, TweenStageDelegate step)
        {
            Reset();
            SetTotalTime(totalTime);
            SetStep(step);
        }
        #endregion

        #region Public Chainable Methods
        public ComplexDelegateTween SetTotalTime(float totalTime)
        {
            if (totalTime < 0f)
            {
                throw new TotalTimeInvalidException();
            }
            TotalTime = totalTime;
            return this;
        }

        public ComplexDelegateTween SetStart(TweenStageDelegate start)
        {
            _Start = start;
            return this;
        }

        public ComplexDelegateTween SetStep(TweenStageDelegate step)
        {
            _Step = step ?? throw new TweenStepNullException();
            return this;
        }

        public ComplexDelegateTween SetFinish(TweenStageDelegate finish)
        {
            _Finish = finish;
            return this;
        }

        public ComplexDelegateTween SetPause(TweenStageDelegate pause)
        {
            _Pause = pause;
            return this;
        }

        public ComplexDelegateTween SetContinue(TweenStageDelegate cont)
        {
            _Continue = cont;
            return this;
        }

        public ComplexDelegateTween SetReset(TweenStageDelegate reset)
        {
            _Reset = reset;
            return this;
        }

        public ComplexDelegateTween SetProceedingTween(ITween proceedingTween)
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
            ((_Start == null) ? _Step : _Start)(0, TotalTime);
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
            ((_Finish == null) ? _Finish : _Step)(CurrentTime, TotalTime);
            IsRunning = false;
            if (!_ProceedingTween.IsRunning) _ProceedingTween.Start();
            return this;
        }

        public ITween Pause()
        {
            ShouldBeRunningExceptionCheck();
            ShouldNotBePausedExceptionCheck();
            ((_Pause == null) ? _Step : _Pause)(CurrentTime, TotalTime);
            IsPaused = true;
            return this;
        }

        public ITween Continue()
        {
            ShouldBeRunningExceptionCheck();
            ShouldBePausedExceptionCheck();
            ((_Continue == null) ? _Step : _Continue)(CurrentTime, TotalTime);
            IsPaused = false;
            return this;
        }

        public ITween Reset()
        {
            ((_Reset == null) ? _Step : _Reset)(CurrentTime, TotalTime);
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
