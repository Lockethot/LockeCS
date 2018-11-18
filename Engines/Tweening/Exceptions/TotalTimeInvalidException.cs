using System;

namespace Lockethot.Engines.Tweening
{
    public class TotalTimeInvalidException : ArgumentException
    {
        public TotalTimeInvalidException() : base("The total time of a Tween cannot be negative.") { }
    }
}
