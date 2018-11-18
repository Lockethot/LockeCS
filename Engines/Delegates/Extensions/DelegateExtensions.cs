using System;
using System.Linq;

namespace Lockethot.Engines.Delegates
{
    public static class DelegateExtensions
    {
        public static Type GetReturnType(this Delegate del)
        {
            return del.Method.ReturnType;
        }

        public static Type[] GetParameterTypes(this Delegate del)
        {
            var parameterInfo = del.Method.GetParameters();
            var ret = new Type[parameterInfo.Length];
            for (var i = 0; i < parameterInfo.Length; i ++)
            {
                ret[i] = parameterInfo[i].ParameterType;
            }
            return ret;
        }

        public static DelegateWrapper Wrap(this Delegate del)
        {
            var types = del.GetParameterTypes();
            var retType = del.GetReturnType();
            if (retType == typeof(void))
            {
                if (types.Length == 0)
                {
                    return new ActionWrapper((Action)del);
                }
                else if (types.Length <= 16)
                {
                    var wrapperType = typeof(ActionWrapper<>).MakeGenericType(types);
                    return (DelegateWrapper)Activator.CreateInstance(wrapperType, del);
                }
                //else
                return new DelegateWrapper(del);
            }
            //else if (retType != typeof(void))
            if (types.Length == 0)
            {
                var wrapperType = typeof(FuncWrapper<>).MakeGenericType(retType);
                return (DelegateWrapper)Activator.CreateInstance(wrapperType, del);
            }
            else if (types.Length >= 16)
            {
                var genericsList = types.ToList();
                genericsList.Add(retType);
                var wrapperType = typeof(FuncWrapper<>).MakeGenericType(genericsList.ToArray());
                return (DelegateWrapper)Activator.CreateInstance(wrapperType, del);
            }
            //else
            return new DelegateWrapper(del);
        }
    }
}
