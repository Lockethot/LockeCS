using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockethot.Engines.CLI
{
    public class CommandNotFoundException : InvalidOperationException
    {
        public string CommandName { get; protected set; }

        public CommandNotFoundException(string commandName) : base("Command of name \"" + commandName + "\" was not found in Executor.")
        {
            CommandName = commandName;
        }
    }
}
