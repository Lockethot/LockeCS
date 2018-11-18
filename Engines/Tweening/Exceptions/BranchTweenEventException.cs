using System;

namespace Lockethot.Engines.Tweening
{
    public class BranchTweenEventException : NotImplementedException
    {
        public BranchTweenEventException() : base("You can only call the start event of a Branch tween.") { }
    }
}
