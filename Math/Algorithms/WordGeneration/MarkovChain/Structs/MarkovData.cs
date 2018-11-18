using Lockethot.Collections.Generic;
using System.Collections.Generic;

namespace Lockethot.Math.Algorithms.WordGeneration.MarkovChain
{
    public struct MarkovData
    {
        public ImmutableArray<System.Collections.Generic.Dictionary<MarkovKey, ImmutableArray<MarkovPair>>> Data { get; private set; }
    }
}
