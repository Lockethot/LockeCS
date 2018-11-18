using System;
using System.Collections.Generic;

namespace Lockethot.Collections.Generic
{
    public class ReversableStack<T>
    {
        #region Protected Properties
        protected Stack<T> _Done = new Stack<T>();
        protected Stack<T> _Undone = new Stack<T>();
        #endregion

        #region Immutable Properties
        public int TotalCount { get { return _Done.Count + _Undone.Count; } }
        public int DoneCount { get { return _Done.Count; } }
        public int UndoneCount { get { return _Undone.Count; } }
        public bool CanRedo { get { return _Undone.Count > 0; } }
        public bool CanUndo { get { return _Done.Count > 0; } }
        #endregion

        #region Constructors
        public ReversableStack() { }
        #endregion

        #region Public Virtual Methods
        public virtual void Do(T item)
        {
            _Done.Push(item);
            ClearUndone();
        }

        public virtual T Undo()
        {
            var ret = _Done.Pop();
            _Undone.Push(ret);
            return ret;
        }

        public virtual T[] Undo(int amount)
        {
            var ret = new List<T>();
            for (var i = 0; i < amount; i ++)
            {
                ret.Add(Undo());
            }
            return ret.ToArray();
        }

        public virtual T PeekDone()
        {
            return _Done.Peek();
        }

        public virtual T Redo()
        {
            try
            {
                var ret = _Undone.Pop();
                _Done.Push(ret);
                return ret;
            }
            catch (IndexOutOfRangeException)
            {
                throw new RedoNotPossibleException();
            }
        }

        public virtual T[] Redo(int amount)
        {
            var ret = new List<T>();
            for (var i = 0; i < amount; i++)
            {
                ret.Add(Redo());
            }
            return ret.ToArray();
        }

        public virtual T PeekUndone()
        {
            return _Undone.Peek();
        }

        public virtual void ClearUndone()
        {
            _Undone.Clear();
        }
        #endregion
    }
}
