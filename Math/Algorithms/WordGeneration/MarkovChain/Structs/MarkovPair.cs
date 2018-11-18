using Lockethot.Collections.Extensions;

namespace Lockethot.Math.Algorithms.WordGeneration.MarkovChain
{
    public struct MarkovPair
    {
        #region Immutable Properties
        public char FollowingChar { get; private set; }
        public int Count { get; private set; }
        #endregion

        #region Constructors
        public MarkovPair(char followingChar, int count)
        {
            FollowingChar = followingChar;
            Count = count;
        }
        #endregion

        #region Public Overrides
        public override string ToString()
        {
            return "{MarkovPair: FollowingChar = \'" + FollowingChar.ToEscapeString() + "\', Count = " + Count.ToString() + "}";
        }
        #endregion
    }
}
