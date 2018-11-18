using System;
using System.Collections.Generic;
using System.Linq;

namespace Lockethot.Engines.Tweening
{
    public class BranchTween : ITween
    {
        #region Private Properties
        private ITween[] _BranchingTweens;
        #endregion

        #region Immutable ITween Properties
        public float CurrentTime { get { throw new BranchTweenPropertyException(); } }
        public float TotalTime { get { throw new BranchTweenPropertyException(); } }
        public bool IsRunning { get { return false; } }
        public bool IsPaused { get { return false; } }
        #endregion

        #region Immutable Properties
        public int BranchCount { get { return _BranchingTweens.Length; } }
        #endregion

        #region Constructors
        public BranchTween(IEnumerable<ITween> branchingTweens)
        {
            _BranchingTweens = branchingTweens.ToArray();
        }
        #endregion

        #region ITween Public Chainable Methods
        public ITween Start()
        {
            for(var i = 0; i < _BranchingTweens.Length; i ++)
            {
                _BranchingTweens[i].Start();
            }
            return this;
        }

        public ITween Step(float deltaTime)
        {
            throw new BranchTweenEventException();
        }

        public ITween Finish()
        {
            throw new NotImplementedException();
        }

        public ITween Pause()
        {
            throw new BranchTweenEventException();
        }

        public ITween Continue()
        {
            throw new BranchTweenEventException();
        }

        public ITween Reset()
        {
            throw new BranchTweenEventException();
        }
        #endregion
    }
}
