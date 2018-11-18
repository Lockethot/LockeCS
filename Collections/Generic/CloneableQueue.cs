using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockethot.Collections.Generic
{
    class CloneableQueue<T> : Queue<T>, ICloneableCollection
    {
        #region Constructors
        public CloneableQueue() : base() { }

        public CloneableQueue(Queue<T> raw = null) : base()
        {
            if (raw != null)
            {
                foreach (var item in raw.Reverse())
                {
                    Enqueue(item);
                }
            }
        }
        #endregion

        #region Interface Implementations
        public object BaseData()
        {
            var ret = new Queue<T>();
            foreach(var item in this.Reverse())
            {
                ret.Enqueue(item);
            }
            return ret;
        }

        public object BaseDataClone()
        {
            var ret = new Queue<T>();
            foreach (var item in this.Reverse())
            {
                ret.Enqueue((item is ICloneable) ? (T)((ICloneable)item).Clone() : item);
            }
            return ret;
        }

        public object Clone()
        {
            var ret = new CloneableQueue<T>();
            foreach (var item in this.Reverse())
            {
                ret.Enqueue((item is ICloneable) ? (T)((ICloneable)item).Clone() : item);
            }
            return ret;
        }
        #endregion
    }
}
