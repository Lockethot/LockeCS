using System;

namespace Lockethot.Engines.Tweening
{
    class TweenAlreadyHandledException : InvalidOperationException
    {
        public TweenAlreadyHandledException() : base("A Tween has been added to the TweenHandler that has already been handled!") { }
    }
}
