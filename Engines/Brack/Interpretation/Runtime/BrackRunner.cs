using System;
using System.Linq;

namespace Lockethot.Engines.Brack
{
    public static class BrackRunner
    {
        public static object Execute(BrackRuntimeData brd, string path = null, Type[] returnTypes = null, SpecialTypes[] specialReturnTypes = null, int[] statementID = null)
        {
            BrackPositionData bpd = new BrackPositionData()
            {
                FileName = path,
                BrackRuntimeData = brd
            };
            object[][] statements = BrackSerialization.ReadBrack(path);
            for(var i = 0; i < statements.Length; i ++)
            {
                bpd.NextStatement();
                var ret = brd.ExecuteOperator(statements[i], bpd);
                if ((returnTypes != null && returnTypes.Contains(ret.GetType())) || (specialReturnTypes != null &(ret is SpecialTypes && specialReturnTypes.Contains((SpecialTypes)ret))))
                {
                    return ret;
                }
            }
            return null;
        }
    }
}
