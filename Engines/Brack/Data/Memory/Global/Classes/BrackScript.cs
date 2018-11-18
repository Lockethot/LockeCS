using System;
using System.Collections.Generic;

namespace Lockethot.Engines.Brack
{
    public class BrackScript
    {
        private object[][] _BrackStatements;

        private string[] _ArgumentNames;

        public string[] ArgumentNames => (string[])_ArgumentNames.Clone();

        public int ArgumentCount
        {
            get
            {
                return _ArgumentNames.Length;
            }
        }

        public string FileName { get; private set; }

        public int[] StatementID { get; private set; }

        public string ScriptName { get; private set; }

        public BrackScript(string scriptName, string fileName, int[] statementID, object[][] brackStatements, string[] argumentNames, BrackPositionData bpd = null)
        {
            ScriptName = scriptName;
            FileName = fileName;
            StatementID = statementID;
            _BrackStatements = brackStatements;
            _ArgumentNames = argumentNames;
            var checkedArgs = new List<string>();
            for(var i = 0; i < argumentNames.Length; i ++)
            {
                if (checkedArgs.Contains(argumentNames[i]))
                {
                    throw new BrackScriptArgumentNameMatchException(ScriptName, argumentNames[i], FileName, bpd?.StatementID);
                }
            }
        }

        public object ExecuteScript(BrackRuntimeData brd, object[] arguments, BrackPositionData bpd = null)
        {
            if (brd == null) throw new ArgumentNullException("brd");
            if (arguments == null) throw new ArgumentNullException("arguments");
            if (arguments.Length != ArgumentCount)
            {
                throw new BrackScriptArgumentCountException(ScriptName, ArgumentCount, arguments.Length, bpd?.FileName, bpd?.StatementID);
            }
            Return ret = null;
            brd.AddLocalMemory();
            for (var i = 0; i < ArgumentCount; i++)
            {
                brd.SetLocalVar(_ArgumentNames[i], arguments[i]);
            }
            ret = (Return)BrackRunner.Execute(brd, FileName, new Type[1] { typeof(Return) }, null, StatementID);
            brd.RemoveLocalMemory();
            return ret?.Data;
        }
    }
}
