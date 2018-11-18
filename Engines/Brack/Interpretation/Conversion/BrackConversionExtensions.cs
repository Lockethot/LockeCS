using System.Text;

namespace Lockethot.Engines.Brack
{
    public static class BrackConversionExtensions
    {
        public static string ToBrackString(this object[][] statements)
        {
            var ret = new StringBuilder();
            for(var i = 0; i < statements.Length; i ++)
            {
                ret.Append(statements[i].ToBrackString());
                ret.Append("\n");
            }
            return ret.ToString();
        }

        public static string ToBrackString(this object[] statement)
        {
            var ret = new StringBuilder("[");
            for (var i = 0; i < statement.Length; i ++)
            {
                if (statement[i] is object[])
                {
                    ret.Append(((object[])statement[i]).ToBrackString());
                }
                else
                {
                    ret.Append(statement[i].ToString());
                    if (i < statement.Length - 1)
                    {
                        ret.Append(" ");
                    }
                }
            }
            ret.Append("[");
            return ret.ToString();
        }
    }
}
