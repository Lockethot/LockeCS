using System;
using System.Collections.Generic;

namespace Lockethot.Collections.Generic
{
    public class CloneableStack<T> : Stack<T>, ICloneableCollection
    {
        #region Constructors
        public CloneableStack() : base () { }

        public CloneableStack(Stack<T> raw = null) : base()
        {
            if (raw != null)
            {
                foreach (var item in raw)
                {
                    Push(item);
                }
            }
        }
        #endregion

        #region Interface Implementations
        public object Clone()
        {
            var ret = new CloneableStack<T>();
            foreach(var item in this)
            {
                ret.Push((item is ICloneable) ? (T)((ICloneable)item).Clone() : item);
            }
            return ret;
        }

        public object BaseData()
        {
            var ret = new Stack<T>();
            foreach(var item in this)
            {
                ret.Push(item);
            }
            return ret;
        }

        public object BaseDataClone()
        {
            var ret = new Stack<T>();
            foreach (var item in this)
            {
                ret.Push((item is ICloneable) ? (T)((ICloneable)item).Clone() : item);
            }
            return ret;
        }
        #endregion
    }
}
