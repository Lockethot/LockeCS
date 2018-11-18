using System;

namespace Lockethot.Engines.Brack
{
    public abstract class BrackOperatorBase
    {
        protected Delegate _OperatorDelegate;
        protected Type[] _ArgumentTypes;
        protected Type _ParamType;

        public Delegate OperatorDelegate => _OperatorDelegate;
        public string OpName { get; protected set; }
        public Type[] ArgumentTypes => (_ArgumentTypes == null) ? null : (Type[])_ArgumentTypes.Clone();
        public int ArgumentCount => (_ArgumentTypes == null) ? -1 : _ArgumentTypes.Length;
        public Type ParamType => _ParamType;
        public bool IsParamOperator => _ParamType != null;

        public BrackOperatorBase(string opName, Delegate operation)
        {
            OpName = opName;
            _OperatorDelegate = operation;
        }

        public virtual object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            if (!IsParamOperator)
            {
                if (args.Length != _ArgumentTypes.Length)
                {
                    throw new BrackOperatorArgumentCountException(ArgumentCount, args.Length, OpName, bpd.FileName, bpd.StatementID);
                }
                for(var i = 0; i < ArgumentCount; i ++)
                {
                    if (args[i].GetType() != _ArgumentTypes[i])
                    {
                        throw new BrackOperatorArgumentTypeException(args[i].GetType(), _ArgumentTypes[i], i, OpName, bpd.FileName, bpd.StatementID);
                    }
                }
            }
            else //if (IsParamOperator)
            {
                for(var i = 0; i < args.Length; i ++)
                {
                    if (args[i].GetType() != _ParamType)
                    {
                        throw new BrackOperatorArgumentTypeException(args[i].GetType(), _ParamType, i, OpName, bpd.FileName, bpd.StatementID);
                    }
                }
            }
            return null;
        }
    }

    public class BrackParamOperator<T> : BrackOperatorBase
    {
        public BrackParamOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ParamType = typeof(T);
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            T[] final = new T[args.Length];
            for(var i = 0; i < args.Length; i ++)
            {
                final[i] = (T)args[i];
            }
            return ((BrackParamDelegate<T>)_OperatorDelegate)(brd, bpd, final);
        }
    }

    public class BrackOperator : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[0];
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate)_OperatorDelegate)(brd, bpd);
        }
    }

    public class BrackOperator<T1> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[1] { typeof(T1), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1>)_OperatorDelegate)(brd, bpd, (T1)args[0]);
        }
    }

    public class BrackOperator<T1, T2> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[2] { typeof(T1), typeof(T2) };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1]);
        }
    }

    public class BrackOperator<T1, T2, T3> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[3] { typeof(T1), typeof(T2), typeof(T3) };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[4] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[5] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5, T6> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[6] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5, T6>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5, T6, T7> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[7] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5, T6, T7>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5, T6, T7, T8> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[8] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5, T6, T7, T8>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5, T6, T7, T8, T9> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[9] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[10] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[11] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[12] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[13] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[14] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13]);
        }
    }

    public class BrackOperator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : BrackOperatorBase
    {
        public BrackOperator(string opName, Delegate operation) : base(opName, operation)
        {
            _ArgumentTypes = new Type[15] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), };
        }

        public override object Execute(BrackRuntimeData brd, BrackPositionData bpd, object[] args)
        {
            base.Execute(brd, bpd, args);
            return ((BrackDelegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>)_OperatorDelegate)(brd, bpd, (T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14]);
        }
    }
}
