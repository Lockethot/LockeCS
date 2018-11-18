using System;
using System.Collections.Generic;
using System.Linq;

namespace Lockethot.Engines.Tweening
{
    public class DelayedInvokeTween : ITween
    {
        #region Private Properties
        private Delegate _ToInvoke;
        private object[] _Arguments;
        #endregion

        #region Immutable Properties
        public float CurrentTime { get; private set; }
        public float TotalTime { get; private set; }
        public bool IsRunning { get; private set; }
        public bool IsPaused { get; private set; }
        #endregion

        #region Constructors
        public DelayedInvokeTween(float totalTime, Delegate toInvoke, IEnumerable<object> arguments = null)
        {
            SetTotalTime(totalTime);
            SetToInvoke(toInvoke);
            _Arguments = (arguments != null) ? arguments.ToArray() : null;
            Reset();
        }
        #endregion

        #region Public Chainable Methods
        public DelayedInvokeTween SetTotalTime(float totalTime)
        {
            if (totalTime < 0f)
            {
                throw new TotalTimeInvalidException();
            }
            TotalTime = totalTime;
            return this;
        }

        public DelayedInvokeTween SetToInvoke(Delegate toInvoke)
        {
            _ToInvoke = toInvoke ?? throw new DelayedInvokeTweenDelegateNullException();
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
            CurrentTime = TotalTime;
            _ToInvoke.DynamicInvoke(_Arguments);
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
