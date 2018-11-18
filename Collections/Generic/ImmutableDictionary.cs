using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lockethot.Collections.Generic
{
    public class ImmutableDictionary<T1,T2>: ICloneable, IEnumerable<KeyValuePair<T1,T2>>, IImmutableCollection
    {
        #region Private Properties
        private readonly CloneableDictionary<T1, T2> _Data;
        #endregion

        #region Immutable Properties
        public int Count
        {
            get
            {
                try
                {
                    return _Data.Count;
                }
                catch (NullReferenceException)
                {
                    throw new ImmutableCollectionNullException(typeof(Dictionary<T1, T2>));
                }
            }
        }

        public bool IsNull => _Data == null;
        #endregion

        #region Constructors
        public ImmutableDictionary(Dictionary<T1, T2> data)
        {
            _Data = new CloneableDictionary<T1, T2>(data);
        }

        public ImmutableDictionary(CloneableDictionary<T1, T2> data)
        {
            _Data = data;
        }
        #endregion

        #region Accessor
        public T2 this[T1 i]
        {
            get
            {
                try
                {
                    return _Data[i];
                }
                catch (NullReferenceException)
                {
                    throw new ImmutableCollectionNullException(typeof(Dictionary<T1, T2>));
                }
            }
        }
        #endregion

        #region Public Methods
        public long LongCount()
        {
            try
            {
                return _Data.LongCount();
            }
            catch (NullReferenceException)
            {
                throw new ImmutableCollectionNullException(typeof(Dictionary<T1, T2>));
            }
        }
        public object Clone()
        {
            return new ImmutableDictionary<T1,T2>((Dictionary<T1,T2>)_Data.Clone());
        }

        public object DataClone()
        {
            try
            {
                return _Data.Clone();
            }
            catch (NullReferenceException)
            {
                throw new ImmutableCollectionNullException(typeof(Dictionary<T1, T2>));
            }
        }

        public object BaseDataClone()
        {
            try
            {
                return ((CloneableDictionary<T1, T2>)_Data.Clone()).BaseData();
            }
            catch (NullReferenceException)
            {
                throw new ImmutableCollectionNullException(typeof(Dictionary<T1, T2>));
            }
        }

        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            try
            {
                return _Data.GetEnumerator();
            }
            catch (NullReferenceException)
            {
                throw new ImmutableCollectionNullException(typeof(Dictionary<T1, T2>));
            }
        }


        #endregion
    }
}
