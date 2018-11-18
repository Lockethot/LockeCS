using Lockethot.Collections.Generic;
using System;

namespace Lockethot.Engines.Delegates
{
    public abstract class FuncWrapperBase<T> : DelegateWrapper
    {
        protected FuncWrapperBase(Delegate del) : base()
        {
            _Del = del ?? throw new ArgumentNullException("del");
            ReturnType = typeof(T);
            HasReturn = true;
        }
    }

    public class FuncWrapper<T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[0]);
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            return ((Func<T>)_Del)();
        }
    }

    public class FuncWrapper<T1, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[1] { typeof(T1) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T>)_Del)((T1)arguments[0]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[2] { typeof(T1), typeof(T2) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T>)_Del)((T1)arguments[0], (T2)arguments[1]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[3] { typeof(T1), typeof(T2), typeof(T3) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[4] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[5] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T6, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T6, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[6] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T6, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T6, T7, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[7] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T6, T7, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[8] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[9] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[10] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[11] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[12] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10], (T12)arguments[11]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[13] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10], (T12)arguments[11], (T13)arguments[12]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[14] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10], (T12)arguments[11], (T13)arguments[12], (T14)arguments[13]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class FuncWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T> : FuncWrapperBase<T>
    {
        public FuncWrapper(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[16] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                return ((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T>)_Del)((T1)arguments[0], (T2)arguments[1], (T3)arguments[2], (T4)arguments[3], (T5)arguments[4], (T6)arguments[5], (T7)arguments[6], (T8)arguments[7], (T9)arguments[8], (T10)arguments[9], (T11)arguments[10], (T12)arguments[11], (T13)arguments[12], (T14)arguments[13], (T15)arguments[14], (T16)arguments[15]);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }

    public class ArrayFuncWrapper<T1, T> : FuncWrapperBase<T>
    {
        public ArrayFuncWrapper(ArrayFunc<T1, T> del) : base(del)
        {
            ArgumentTypes = new ImmutableArray<Type>(new Type[1] { typeof(T1) });
        }

        public override object Execute(object[] arguments)
        {
            CheckArgumentCount(arguments.Length);
            try
            {
                var final = new T1[arguments.Length];
                for (var i = 0; i < arguments.Length; i++)
                {
                    final[i] = (T1)arguments[i];
                }
                return ((ArrayFunc<T1, T>)_Del)(final);
            }
            catch (InvalidCastException)
            {
                throw new DelegateWrapperArgumentTypeException();
            }
        }
    }
}
