using Lockethot.Collections.Generic;
using Lockethot.Engines.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lockethot.Engines.CLI
{
    public class CommandLineExecutor
    {
        public readonly CloneableDictionary<string, ActionWrapperBase> Commands = new CloneableDictionary<string, ActionWrapperBase>();

        public CommandLineExecutor(CommandLineAction[] commands)
        {
            for(var i = 0; i < commands.Length; i ++)
            {
                Commands[commands[i].Name] = commands[i].Action;
            }
        }

        public virtual void ExecuteCommand(object[] command)
        {
            ExecuteCommand(command[0].ToString(), command.Skip(1).ToArray());
        }

        public virtual void ExecuteCommand(string name, object[] arguments)
        {
            try
            {
                Commands[name].Execute(arguments);
            }
            catch(KeyNotFoundException)
            {
                throw new CommandNotFoundException(name);
            }
        }
    }
}
