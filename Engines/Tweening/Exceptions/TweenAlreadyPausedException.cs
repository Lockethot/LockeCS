using System;

namespace Lockethot.Engines.Tweening
{
    public class TweenAlreadyPausedException : InvalidOperationException
    {
        public TweenAlreadyPausedException() : base("You cannot pause a Tween that has already been paused.") { }
    }
}
