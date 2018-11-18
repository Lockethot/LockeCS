using System;

namespace Lockethot.Engines.Tweening
{
    public class DelayedInvokeTweenDelegateNullException : NullReferenceException
    {
        public DelayedInvokeTweenDelegateNullException() : base("The toInvoke delegate of a DelayedInvokeTween cannot be null.") { }
    }
}
