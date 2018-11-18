using Lockethot.Collections.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Lockethot.Engines.Brack
{
    public class BrackPositionData
    {
        public BrackRuntimeData BrackRuntimeData;

        private List<int> _StatementID;

        public int[] StatementID => _StatementID.ToArray();

        public string FileName = "";

        public int MemoryLevel => BrackRuntimeData.LocalMemoryCount;

        public int ScopeLevel => BrackRuntimeData.ScopeCount;

        public BrackPositionData(int[] statementID = null)
        {
            if (statementID == null)
            {
                _StatementID = new List<int>();
            }
            else
            {
                _StatementID = statementID.ToList();
            }
        }

        public void NextStatement()
        {
            _StatementID[_StatementID.FinalIndex()]++;
        }

        public void BranchStatement()
        {
            _StatementID.Add(1);
        }

        public void UnbranchStatement()
        {
            _StatementID.PopLast();
        }

        public void SetScript(BrackScript script)
        {

        }
    }
}
