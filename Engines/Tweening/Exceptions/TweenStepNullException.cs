using System;

namespace Lockethot.Engines.Tweening
{
    public class TweenStepNullException : NullReferenceException
    {
        public TweenStepNullException() : base("The step TweenStageDelegate of a Tween cannot be null.") { }
    }
}
