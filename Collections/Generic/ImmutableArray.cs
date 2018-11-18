using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lockethot.Collections.Generic
{
    public class ImmutableArray<T> : ICloneable, IEnumerable<T>, IImmutableCollection
    {
        #region Private Properties
        private readonly T[] _Data;
        #endregion

        #region Immutable Properties
        public int Length
        {
            get
            {
                try
                {
                    return _Data.Length;
                }
                catch (NullReferenceException)
                {
                    throw new ImmutableCollectionNullException(typeof(T[]));
                }
            }
        }

        public long LongLength
        {
            get
            {
                try
                {
                    return _Data.LongLength;
                }
                catch (NullReferenceException)
                {
                    throw new ImmutableCollectionNullException(typeof(T[]));
                }
            }
        }

        public bool IsReadOnly => true;

        public bool IsFixedSize => true;

        public bool IsNull => _Data == null;
        #endregion

        #region Constructors
        public ImmutableArray(T[] data)
        {
            _Data = data;
        }
        #endregion

        #region Accessor
        public T this[int i]
        {
            get
            {
                try
                {
                    return _Data[i];
                }
                catch (NullReferenceException)
                {
                    throw new ImmutableCollectionNullException(typeof(T[]));
                }
            }
        }
        #endregion

        #region Public Methods
        public object Clone()
        {
            try
            {
                return new ImmutableArray<T>((T[])DataClone());
            }
            catch (NullReferenceException)
            {
                throw new ImmutableCollectionNullException(typeof(T[]));
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            try
            {
                return (IEnumerator<T>)_Data.GetEnumerator();
            }
            catch (NullReferenceException)
            {
                throw new ImmutableCollectionNullException(typeof(T[]));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T value)
        {
            try
            {
                return _Data.Contains(value);
            }
            catch (NullReferenceException)
            {
                throw new ImmutableCollectionNullException(typeof(T[]));
            }
        }

        public object DataClone()
        {    
            try
            {
                 return _Data.Clone();
            }
            catch (NullReferenceException)
            {
                throw new ImmutableCollectionNullException(typeof(T[]));
            }
        }
        #endregion
    }
}
