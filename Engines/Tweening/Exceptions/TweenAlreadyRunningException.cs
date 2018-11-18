using System;

namespace Lockethot.Engines.Tweening
{
    public class TweenAlreadyRunningException : InvalidOperationException
    {
        public TweenAlreadyRunningException() : base("You cannot start a Tween that is already running.") { }
    }

}
