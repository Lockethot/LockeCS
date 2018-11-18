using System;
using System.Collections.Generic;

namespace Lockethot.Engines.Tweening
{
    public class TweenHandler
    {
        #region Private Properties
        private List<ITween> _Tweens = new List<ITween>();
        #endregion

        #region Immutable Properties
        public float ActiveDeltaTime { get; private set; }
        public int TweenCount { get { return _Tweens.Count; } }
        #endregion

        #region Public Properties
        public bool IsActive { get; set; }
        #endregion

        #region Constructors
        public TweenHandler() { }
        #endregion


        #region Public Utility Methods
        public void AddTween(ITween tween)
        {
            try
            {
                _Tweens.Add(tween);
            }
            catch (Exception)
            {
                throw new TweenAlreadyHandledException();
            }
        }

        public void RemoveTween(ITween tween)
        {
            try
            {
                _Tweens.Remove(tween);
            }
            catch (Exception)
            {
                throw new TweenNotHandledException();
            }
        }

        public void RemoveTween(int index)
        {
            try
            {
                _Tweens.RemoveAt(index);
            }
            catch (Exception)
            {
                throw new TweenIndexOutOfRangeException(index);
            }
        }

        public ITween GetTween(int index)
        {
            return _Tweens[index];
        }

        public int GetIndex(ITween tween)
        {
            try
            {
                return _Tweens.IndexOf(tween);
            }
            catch (Exception)
            {
                throw new TweenNotHandledException();
            }
        }

        public bool HandlesTween(ITween tween)
        {
            return _Tweens.Contains(tween);
        }

        public void Step(float deltaTime)
        {
            if (IsActive)
            {
                for (var i = 0; i < _Tweens.Count; i++)
                {
                    _Tweens[i].Step(deltaTime);
                }
                ActiveDeltaTime += deltaTime;
            }
        }

        public void Clear()
        {
            ActiveDeltaTime = 0f;
            _Tweens = new List<ITween>();
        }

        public void ResetAll()
        {
            ActiveDeltaTime = 0f;
            for (var i = 0; i < _Tweens.Count; i++)
            {
                _Tweens[i].Reset();
            }
        }
        #endregion
    }
}
