namespace Lockethot.Engines.Brack
{
    public class BrackLogicException : BrackException
    {
        private int[] _StatementID;

        public int[] StatementID
        {
            get
            {
                return (int[])_StatementID.Clone();
            }
        }

        public BrackLogicException(string fileName = null, int[] statementID = null) : this("A Brack Logic error has occured!", fileName, statementID) { }
        public BrackLogicException(string message, string fileName = null, int[] statementID = null) : base("LOGIC<" +  StatementIDToString(statementID) + ">: " + message, fileName)
        {
            _StatementID = (int[])statementID.Clone();
        }

        public static string StatementIDToString(int[] statementID)
        {
            if (statementID == null) return "NA";
            string ret = "";
            for (var i = 0; i < statementID.Length; i++)
            {
                ret += statementID[i].ToString();
                if (i < statementID.Length - 1)
                {
                    ret += ",";
                }
            }
            return ret;
        }
    }
}
