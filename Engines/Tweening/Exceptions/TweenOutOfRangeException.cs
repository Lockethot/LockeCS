using System;

namespace Lockethot.Engines.Tweening
{
    public class TweenIndexOutOfRangeException : InvalidOperationException
    {
        public TweenIndexOutOfRangeException(int index) : base("No Tween has been found with the index of " + index.ToString() + ".") { }
    }
}
