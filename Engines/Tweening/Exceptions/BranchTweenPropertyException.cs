using System;

namespace Lockethot.Engines.Tweening
{
    public class BranchTweenPropertyException : NotImplementedException
    {
        public BranchTweenPropertyException() : base("The time related variables of a branch tween are not applicable.") { }
    }
}
