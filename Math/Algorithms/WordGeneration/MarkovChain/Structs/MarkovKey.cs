
using Lockethot.Collections.Extensions;

namespace Lockethot.Math.Algorithms.WordGeneration.MarkovChain
{
    public struct MarkovKey
    {
        #region Immutable Properties
        public string Substr { get; private set; }
        public int TotalCount { get; private set; }
        #endregion

        #region Constructors
        public MarkovKey(string substr, int totalCount)
        {
            Substr = substr;
            TotalCount = totalCount;
        }
        #endregion

        #region Operator Overloads
        public static bool operator==(MarkovKey k, string val)
        {
            return k.Substr == val;
        }

        public static bool operator!=(MarkovKey k, string val)
        {
            return k.Substr != val;
        }
        #endregion

        #region Public Overrides
        public override bool Equals(object obj)
        {
            return obj is MarkovKey && ((MarkovKey)obj).Substr == Substr;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "{MarkovKey: Substr = \"" + Substr.ToEscapeString() + "\", TotalCount = " + TotalCount.ToString() +"}";
        }
        #endregion
    }
}
