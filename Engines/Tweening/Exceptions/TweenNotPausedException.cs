using System;

namespace Lockethot.Engines.Tweening
{
    public class TweenNotPausedException : InvalidOperationException
    {
        public TweenNotPausedException() : base("You cannot continue a tween that is not paused.") { }
    }
}
