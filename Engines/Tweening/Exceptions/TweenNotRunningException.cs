using System;

namespace Lockethot.Engines.Tweening
{
    public class TweenNotRunningException : InvalidOperationException
    {
        public TweenNotRunningException() : base("You cannot call events on a Tween that is not running besides the Start event.") { }
    }
}
