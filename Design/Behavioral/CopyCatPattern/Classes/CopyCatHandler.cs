using System;
using System.Collections.Generic;

namespace Lockethot.Design.Behavioral.CopyCatPattern
{
    public class CopyCatHandler<T>
    {
        private List<ICopyCat<T>> _CopyCats = new List<ICopyCat<T>>();
        private T _MasterCat;

        public int CatCount { get { return _CopyCats.Count; } }
        public bool IsEmpty { get { return CatCount != 0; } }
        public T MasterCat
        {
            get
            {
                return _MasterCat;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("The MasterCat of a CopyCatHandler set by setter cannot be null.");
                _MasterCat = value;
            }
        }

        public CopyCatHandler(T masterCat)
        {
            if (masterCat == null) throw new ArgumentNullException("The MasterCat of a CopyCatHandler set by constructor cannot be null.");
            _MasterCat = masterCat;
        }

        public void AddCat(ICopyCat<T> cat)
        {
            if (cat == null) throw new ArgumentNullException("Cats of a CopyCatHandler set by AddCat() cannot be null.");
            if (!HasCat(cat)) _CopyCats.Add(cat);
        }

        public void RemoveCat(ICopyCat<T> cat)
        {
            _CopyCats.Remove(cat);
        }

        public bool HasCat(ICopyCat<T> cat)
        {
            return _CopyCats.Contains(cat);
        }

        public ICopyCat<T> GetCat(int index)
        {
            try
            {
                return _CopyCats[index];
            }
            catch(IndexOutOfRangeException)
            {
                throw new ArgumentException("Index " + index.ToString() + " out of range of CatCount, which is " + CatCount.ToString() + ".");
            }
        }

        public T1 GetCat<T1>(int index)
        {
            try
            {
                return (T1)GetCat(index);
            }
            catch(InvalidCastException)
            {
                throw new InvalidCastException("ICopyCat<> at index " + index.ToString() + " could not be cast to Type " + typeof(T1).ToString() + ".");
            }
        }

        public void UpdateCats()
        {
            for(var i = 0; i < _CopyCats.Count; i ++)
            {
                _CopyCats[i].Copy(_MasterCat);
            }
        }

        public void UpdateCats(T masterCat)
        {
            if (masterCat == null) throw new ArgumentNullException("The MasterCat of a CopyCatHandler set by UpdateCats() cannot be null.");
            _MasterCat = masterCat;
            for (var i = 0; i < _CopyCats.Count; i++)
            {
                _CopyCats[i].Copy(_MasterCat);
            }
        }
    }
}
