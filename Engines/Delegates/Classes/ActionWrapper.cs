using Lockethot.Collections.Generic;
using System;

namespace Lockethot.Engines.Delegates
{
    public abstract class ActionWrapperBase : DelegateWrapper
    {
        protected ActionWrapperBase(Delegate del) : base()
        {
            _Del = del ?? throw new ArgumentNullException("del");
            ReturnType = typeof(void);
            HasReturn = false;
        }
    }

    public class ActionWrapper : ActionWrapperBase
    {
        public ActionWrapper(Action del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[0]);
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            ((Action)_Del)();
            return null;
        }
    }

    public class ActionWrapper<T1> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[1] { typeof(T1) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1>)_Del)((T1)arguments[0]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[2] { typeof(T1), typeof(T2) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1,T2>)_Del)((T1)arguments[0], (T2)arguments[1]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[3] { typeof(T1), typeof(T2), typeof(T3) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[4] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[5] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[6] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6, T7> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6, T7> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[7] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6, T7>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6, T7, T8> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[8] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6, T7, T8>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[9] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[10] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[11] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[12] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10], (T12)arguments[11]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[13] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10], (T12)arguments[11], (T13)arguments[12]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[14] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10], (T12)arguments[11], (T13)arguments[12], (T14)arguments[13]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[15] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10], (T12)arguments[11], (T13)arguments[12], (T14)arguments[13], (T15)arguments[14]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ActionWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : ActionWrapperBase
    {
        public ActionWrapper(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[16] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                ((Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10], (T12)arguments[11], (T13)arguments[12], (T14)arguments[13], (T15)arguments[14], (T16)arguments[15]);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ArrayActionWrapper<T1> : ActionWrapperBase
    {
        public ArrayActionWrapper(ArrayAction<T1> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[1] { typeof(T1) });
        }

        public override object Execute(object[] arguments)
        {
            try
            {
                var final = new T1[arguments.Length];
                for(var i = 0; i < arguments.Length; i ++)
                {
                    final[i] = (T1)arguments[i];
                }
                ((ArrayAction<T1>)_Del)(final);
                return null;
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }
}
