using System;
using System.Collections.Generic;

namespace Lockethot.Design.Creational.SingletonPattern
{
    public static class Singletons
    {
        #region Private Properties
        private static Dictionary<Type, object> _Singletons = new Dictionary<Type, object>();
        #endregion

        #region Public Methods
        public static T GetInstance<T>()
        {
            if (!HasInstance(typeof(T)))
            {
                if (!typeof(T).IsSubclassOf(typeof(Singleton)))
                {
                    throw new TypeNotSingletonException(typeof(T));
                }
                Activator.CreateInstance(typeof(T));
            }
            return (T)_Singletons[typeof(T)];
        }

        public static void SetInstance(object singleton)
        {
            if (!singleton.GetType().IsSubclassOf(typeof(Singleton)))
            {
                throw new TypeNotSingletonException(singleton.GetType());
            }
            else if (HasInstance(singleton.GetType()))
            {
                throw new MultipleSingletonInstancesException(singleton.GetType());
            }
            _Singletons[singleton.GetType()] = singleton;
        }

        public static bool HasInstance<T>()
        {
            return HasInstance(typeof(T));
        }

        public static bool HasInstance(Type type)
        {
            return _Singletons.ContainsKey(type);
        }

        public static void DeleteInstance<T>()
        {
            DeleteInstance(typeof(T));
        }

        public static void DeleteInstance(Type type)
        {
            try
            {
                _Singletons.Remove(type);
            }
            catch (KeyNotFoundException)
            {
                throw new NoSingletonInstanceException(type);
            }
        }
        #endregion
    }
}
