using Lockethot.Design.Behavioral.InterpreterPattern;
using System.Collections.Generic;
using System.Text;

namespace Lockethot.Engines.CLI
{
    public class CommandLineInterpreter : StringArrayInterpreter<object, CommandLineInterpreterData>
    {
        public override object[] Interperet(string raw)
        {
            var ret = new List<object>();
            var dat = new CommandLineInterpreterData();
            for(var i = 0; i < raw.Length; i ++)
            {
                InterpretChar(raw, i, ref dat, ret);
            }
            return ret.ToArray();
        }

        public override void InterpretChar(string raw, int index, ref CommandLineInterpreterData data, List<object> result)
        {
            var curChar = raw[index];
            var befChar = (index == 0) ? ' ' : raw[index - 1];
            if (data.InString)
            {
                if (curChar == '\"' && befChar != '\\')
                {
                    data.InString = false;
                    result.Add(data.Token.ToString());
                    data.Token.Clear();
                }
                else
                {
                    data.Token.Append(curChar);
                }
            }
            else //if (!data.InString)
            {
                if (curChar == '\"' && befChar != '\\')
                {
                    data.InString = true;
                    if (data.Token.Length != 0)
                    {
                        result.Add(ParseArgument(data.Token.ToString()));
                        data.Token.Clear();
                    }
                }
                else if (string.IsNullOrWhiteSpace(curChar.ToString()))
                {
                    if (data.Token.Length != 0)
                    {
                        result.Add(ParseArgument(data.Token.ToString()));
                        data.Token.Clear();
                    }
                }
                else if (index == raw.Length - 1)
                {
                    data.Token.Append(curChar);
                    result.Add(ParseArgument(data.Token.ToString()));
                    data.Token.Clear();
                }
                else
                {
                    data.Token.Append(curChar);
                }
            }
        }

        public virtual object ParseArgument(string raw)
        {
            if (float.TryParse(raw, out float fval))
            {
                return fval;
            }
            else if (bool.TryParse(raw, out bool bval))
            {
                return bval;
            }
            return raw;
        }
    }
}
