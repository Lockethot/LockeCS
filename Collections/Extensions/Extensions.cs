using Lockethot.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lockethot.Collections.Extensions
{
    public static class Extensions
    {
        #region Array Extensions
        public static T PeekLast<T>(this T[] arg)
        {
            return arg[arg.Length - 1];
        }

        public static T PeekFirst<T>(this T[] arg)
        {
            return arg[0];
        }

        public static int FinalIndex<T>(this T[] arg)
        {
            return arg.Length - 1;
        }

        public static bool Equivalent<T>(this T[] arg, T[] b)
        {
            if (arg.Length != b.Length) return false;
            for (var i = 0; i < arg.Length; i++) if (!arg[i].Equals(b[i])) return false;
            return true;
        }

        public static bool Equivalent<T>(this T[] arg, ImmutableArray<T> b)
        {
            if (arg.Length != b.Length) return false;
            for (var i = 0; i < arg.Length; i++) if (!arg[i].Equals(b[i])) return false;
            return true;
        }

        public static bool Equivalent<T>(this T[] arg, List<T> b)
        {
            return arg.Equivalent(b.ToArray());
        }

        public static bool ContainsArray<T>(this T[] arg, T[] b)
        {
            for (var i = 0; i < arg.Length - b.Length; i++) if (arg.Skip(i).Take(b.Length).ToArray().Equivalent(b)) return true;
            return false;
        }

        public static bool ContainsArray<T>(this T[] arg, ImmutableArray<T> b)
        {
            for (var i = 0; i < arg.Length - b.Length; i++) if (arg.Skip(i).Take(b.Length).ToArray().Equivalent(b)) return true;
            return false;
        }

        public static bool ContainsList<T>(this T[] arg, List<T> b)
        {
            return arg.ContainsArray(b.ToArray());
        }

        public static int IndexOfArray<T>(this T[] arg, T[] b)
        {
            for (var i = 0; i < arg.Length - b.Length; i++) if (arg.Skip(i).Take(b.Length).ToArray().Equivalent(b)) return i;
            return -1;
        }

        public static int IndexOfArray<T>(this T[] arg, ImmutableArray<T> b)
        {
            for (var i = 0; i < arg.Length - b.Length; i++) if (arg.Skip(i).Take(b.Length).ToArray().Equivalent(b)) return i;
            return -1;
        }

        public static int IndexOfList<T>(this T[] arg, List<T> b)
        {
            return arg.IndexOfArray(b.ToArray());
        }

        public static int[] IndicesOfArray<T>(this T[] arg, T[] b)
        {
            var ret = new List<int>();
            for (var i = 0; i < arg.Length - b.Length; i++) if (arg.Skip(i).Take(b.Length).ToArray().Equivalent(b)) ret.Add(i);
            return ret.ToArray();
        }

        public static int[] IndicesOfArray<T>(this T[] arg, ImmutableArray<T> b)
        {
            var ret = new List<int>();
            for (var i = 0; i < arg.Length - b.Length; i++) if (arg.Skip(i).Take(b.Length).ToArray().Equivalent(b)) ret.Add(i);
            return ret.ToArray();
        }

        public static int[] IndicesOfList<T>(this T[] arg, List<T> b)
        {
            return arg.IndicesOfArray(b.ToArray());
        }

        public static int[] IndicesOf<T>(this T[] arg, T b)
        {
            var ret = new List<int>();
            for (var i = 0; i < arg.Length; i++) if (arg[i].Equals(b)) ret.Add(i);
            return ret.ToArray();
        }
        #endregion

        #region List Extensions
        public static T PopLast<T>(this List<T> arg)
        {
            var ret = arg[arg.Count - 1];
            arg.RemoveAt(arg.Count - 1);
            return ret;
        }

        public static T PeekLast<T>(this List<T> arg)
        {
            return arg[arg.Count - 1];
        }

        public static T PopFirst<T>(this List<T> arg)
        {
            var ret = arg[0];
            arg.RemoveAt(0);
            return ret;
        }

        public static T PeekFirst<T>(this List<T> arg)
        {
            return arg[0];
        }

        public static T PopAt<T>(this List<T> arg, int index)
        {
            var ret = arg[index];
            arg.RemoveAt(index);
            return ret;
        }

        public static int FinalIndex<T>(this List<T> arg)
        {
            return arg.Count - 1;
        }

        public static bool Equivalent<T>(this List<T> arg, List<T> b)
        {
            return arg.ToArray().Equivalent(b.ToArray());
        }

        public static bool Equivalent<T>(this List<T> arg, T[] b)
        {
            return arg.ToArray().Equivalent(b);
        }

        public static bool Equivalent<T>(this List<T> arg, ImmutableArray<T> b)
        {
            return arg.ToArray().Equivalent(b);
        }

        public static bool ContainsList<T>(this List<T> arg, List<T> b)
        {
            return arg.ToArray().ContainsArray(b.ToArray());
        }

        public static bool ContainsArray<T>(this List<T> arg, T[] b)
        {
            return arg.ToArray().ContainsArray(b);
        }

        public static bool ContainsArray<T>(this List<T> arg, ImmutableArray<T> b)
        {
            return arg.ToArray().ContainsArray(b);
        }

        public static int IndexOfList<T>(this List<T> arg, List<T> b)
        {
            return arg.ToArray().IndexOfArray(b.ToArray());
        }

        public static int IndexOfArray<T>(this List<T> arg, T[] b)
        {
            return arg.ToArray().IndexOfArray(b);
        }

        public static int IndexOfArray<T>(this List<T> arg, ImmutableArray<T> b)
        {
            return arg.ToArray().IndexOfArray(b);
        }

        public static int[] IndicesOfList<T>(this List<T> arg, List<T> b)
        {
            return arg.ToArray().IndicesOfArray(b.ToArray());
        }

        public static int[] IndicesOfArray<T>(this List<T> arg, T[] b)
        {
            return arg.ToArray().IndicesOfArray(b);
        }

        public static int[] IndicesOfArray<T>(this List<T> arg, ImmutableArray<T> b)
        {
            return arg.ToArray().IndicesOfArray(b);
        }

        public static int[] IndicesOf<T>(this List<T> arg, T b)
        {
            return arg.ToArray().IndicesOf(b);
        }

        public static void AddRange<T>(this List<T> arg, Stack<T> stack)
        {
            foreach(var item in stack)
            {
                arg.Add(item);
            }
        }

        public static void AddRange<T>(this List<T> arg, Queue<T> queue)
        {
            foreach (var item in queue.Reverse())
            {
                arg.Add(item);
            }
        }

        public static void AddRangeReverse<T>(this List<T> arg, List<T> list)
        {
            for (var i = list.Count - 1; i >= 0; i --)
            {
                arg.Add(list[i]);
            }
        }

        public static void AddRangeReverse<T>(this List<T> arg, T[] array)
        {
            for (var i = array.Length - 1; i >= 0; i --)
            {
                arg.Add(array[i]);
            }
        }

        public static void AddRangeReverse<T>(this List<T> arg, Stack<T> stack)
        {
            foreach (var item in stack.Reverse())
            {
                arg.Add(item);
            }
        }

        public static void AddRangeReverse<T>(this List<T> arg, Queue<T> queue)
        {
            foreach (var item in queue)
            {
                arg.Add(item);
            }
        }
        #endregion

        #region Dictionary Extensions
        public static T[] KeyArray<T, T1>(this System.Collections.Generic.Dictionary<T, T1> arg)
        {
            T[] ret = new T[arg.Count];
            var i = 0;
            foreach(var k in arg)
            {
                ret[i++] = k.Key;
            }
            return ret;
        }

        public static T1[] ValueArray<T, T1>(this System.Collections.Generic.Dictionary<T, T1> arg)
        {
            T1[] ret = new T1[arg.Count];
            var i = 0;
            foreach (var k in arg)
            {
                ret[i++] = k.Value;
            }
            return ret;
        }

        public static KeyValuePair<T1, T2>[] ToKeyValuePairArray<T1, T2>(this System.Collections.Generic.Dictionary<T1, T2> arg)
        {
            var ret = new KeyValuePair<T1, T2>[arg.Count];
            var i = 0;
            foreach(var kvp in arg)
            {
                ret[i++] = kvp;
            }
            return ret;
        }

        public static void AddRange<T1, T2>(this System.Collections.Generic.Dictionary<T1, T2> arg, KeyValuePair<T1, T2>[] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                arg[data[i].Key] = data[i].Value;
            }
        }

        public static void AddRange<T1, T2>(this System.Collections.Generic.Dictionary<T1, T2> arg, T1[] keys, T2[] values)
        {
            if (keys == null) throw new ArgumentNullException("keys");
            if (values == null) throw new ArgumentNullException("values");
            if (keys.Length != values.Length)
            {
                throw new ArgumentException("Not same amount of keys as values in Dictionary<" + typeof(T1).ToString() + "," + typeof(T2).ToString() + ">.AddRange().");
            }
            for (var i = 0; i < keys.Length; i++)
            {
                arg[keys[i]] = values[i];
            }
        }

        public static void AddRange<T1, T2>(this System.Collections.Generic.Dictionary<T1, T2> arg, System.Collections.Generic.Dictionary<T1, T2> data)
        {
            foreach(var kvp in data)
            {
                arg[kvp.Key] = kvp.Value;
            }
        }

        public static void AddRangeReverse<T1, T2>(this System.Collections.Generic.Dictionary<T1, T2> arg, KeyValuePair<T1, T2>[] data)
        {
            for (var i = data.Length - 1; i >= 0; i--)
            {
                arg[data[i].Key] = data[i].Value;
            }
        }

        public static void AddRangeReverse<T1, T2>(this System.Collections.Generic.Dictionary<T1, T2> arg, T1[] keys, T2[] values)
        {
            if (keys == null) throw new ArgumentNullException("keys");
            if (values == null) throw new ArgumentNullException("values");
            if (keys.Length != values.Length)
            {
                throw new ArgumentException("Not same amount of keys as values in Dictionary<" + typeof(T1).ToString() + "," + typeof(T2).ToString() + ">.AddRange().");
            }
            for (var i = keys.Length - 1; i >= 0; i--)
            {
                arg[keys[i]] = values[i];
            }
        }

        public static void AddRangeReverse<T1, T2>(this System.Collections.Generic.Dictionary<T1, T2> arg, System.Collections.Generic.Dictionary<T1, T2> data)
        {
            foreach (var kvp in data.Reverse())
            {
                arg[kvp.Key] = kvp.Value;
            }
        }
        #endregion

        #region Stack Extensions
        public static void PushRange<T>(this Stack<T> arg, Stack<T> stack)
        {
            foreach(var item in stack)
            {
                arg.Push(item);
            }
        }

        public static void PushRange<T>(this Stack<T> arg, T[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                arg.Push(array[i]);
            }
        }

        public static void PushRange<T>(this Stack<T> arg, List<T> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                arg.Push(list[i]);
            }
        }

        public static void PushRange<T>(this Stack<T> arg, Queue<T> queue)
        {
            foreach(var item in queue.Reverse())
            {
                arg.Push(item);
            }
        }

        public static void PushRangeReverse<T>(this Stack<T> arg, Stack<T> stack)
        {
            foreach (var item in stack.Reverse())
            {
                arg.Push(item);
            }
        }

        public static void PushRangeReverse<T>(this Stack<T> arg, T[] array)
        {
            for (var i = array.Length - 1; i >= 0; i--)
            {
                arg.Push(array[i]);
            }
        }

        public static void PushRangeReverse<T>(this Stack<T> arg, List<T> list)
        {
            for (var i = list.Count - 1; i >= 0; i--)
            {
                arg.Push(list[i]);
            }
        }

        public static void PushRangeReverse<T>(this Stack<T> arg, Queue<T> queue)
        {
            foreach (var item in queue)
            {
                arg.Push(item);
            }
        }
        #endregion

        #region Queue Extensions
        public static void EnqueueRange<T>(this Queue<T> arg, Stack<T> stack)
        {
            foreach (var item in stack)
            {
                arg.Enqueue(item);
            }
        }

        public static void EnqueueRange<T>(this Queue<T> arg, T[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                arg.Enqueue(array[i]);
            }
        }

        public static void EnqueueRange<T>(this Queue<T> arg, List<T> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                arg.Enqueue(list[i]);
            }
        }

        public static void EnqueueRange<T>(this Queue<T> arg, Queue<T> queue)
        {
            foreach (var item in queue.Reverse())
            {
                arg.Enqueue(item);
            }
        }

        public static void EnqueueRangeReverse<T>(this Queue<T> arg, Stack<T> stack)
        {
            foreach (var item in stack.Reverse())
            {
                arg.Enqueue(item);
            }
        }

        public static void EnqueueRangeReverse<T>(this Queue<T> arg, T[] array)
        {
            for (var i = array.Length - 1; i >= 0; i--)
            {
                arg.Enqueue(array[i]);
            }
        }

        public static void EnqueueRangeReverse<T>(this Queue<T> arg, List<T> list)
        {
            for (var i = list.Count - 1; i >= 0; i--)
            {
                arg.Enqueue(list[i]);
            }
        }

        public static void EnqueueRangeReverse<T>(this Queue<T> arg, Queue<T> queue)
        {
            foreach (var item in queue)
            {
                arg.Enqueue(item);
            }
        }
        #endregion

        #region byte[] Extensions
        public static object ToObject(this byte[] arg)
        {
            using (var memStream = new MemoryStream())
            {
                memStream.Write(arg, 0, arg.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                return new BinaryFormatter().Deserialize(memStream);
            }
        }

        public static T ToObject<T>(this byte[] arg) => (T)arg.ToObject();
        #endregion

        #region Object Extensions
        public static byte[] ToByteArray(this object arg)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, arg);
                return ms.ToArray();
            }
        }
        public static string ToEscapeString(this object o)
        {
            if (o is char)
            {
                switch ((char)o)
                {
                    case '\'':
                        return "\\'";
                    case '\"':
                        return "\\\"";
                    case '\\':
                        return "\\\\";
                    case '\0':
                        return "\\0";
                    case '\a':
                        return "\\a";
                    case '\b':
                        return "\\b";
                    case '\f':
                        return "\\f";
                    case '\n':
                        return "\\n";
                    case '\r':
                        return "\\r";
                    case '\t':
                        return "\\t";
                    case '\v':
                        return "\\v";
                    default:
                        return o.ToString();
                }
            }
            else
            {
                var str = o.ToString();
                var ret = new StringBuilder("");
                for(var i = 0; i < str.Length; i ++)
                {
                    ret.Append(str[i].ToEscapeString());
                }
                return ret.ToString();
            }
        }
        #endregion
    }
}
