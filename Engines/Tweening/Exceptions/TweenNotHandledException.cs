using System;

namespace Lockethot.Engines.Tweening
{
    public class TweenNotHandledException : InvalidOperationException
    {
        public TweenNotHandledException() : base("A Tween was not found in the TweenHandler.") { }
    }
}
