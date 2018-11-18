using System;
using System.Collections.Generic;

namespace Lockethot.Collections.Generic
{
    public class CloneableDictionary<T1, T2> : Dictionary<T1, T2>, ICloneableCollection
    {
        #region Constructors
        public CloneableDictionary() : base() { }

        public CloneableDictionary(System.Collections.Generic.Dictionary<T1, T2> raw = null) : base()
        {
            if (raw != null)
            {
                foreach (var kvp in raw)
                {
                    this[kvp.Key] = kvp.Value;
                }
            }
        }
        #endregion

        #region Implementations
        public object Clone()
        {
            var ret = new Dictionary<T1, T2>();
            foreach(var kvp in this)
            {
                ret[(kvp.Key is ICloneable) ? (T1)((ICloneable)kvp.Key).Clone() : kvp.Key] = (kvp.Value is ICloneable) ? (T2)((ICloneable)kvp.Value).Clone() : kvp.Value;
            }
            return ret;
        }

        public object BaseData()
        {
            var ret = new System.Collections.Generic.Dictionary<T1, T2>();
            foreach(var kvp in this)
            {
                ret[kvp.Key] = kvp.Value;
            }
            return ret;
        }

        public object BaseDataClone()
        {
            var ret = new System.Collections.Generic.Dictionary<T1, T2>();
            foreach (var kvp in this)
            {
                ret[(kvp.Key is ICloneable) ? (T1)((ICloneable)kvp.Key).Clone() : kvp.Key] = (kvp.Value is ICloneable) ? (T2)((ICloneable)kvp.Value).Clone() : kvp.Value;
            }
            return ret;
        }
        #endregion
    }
}
