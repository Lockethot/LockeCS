using Lockethot.Engines.Delegates;

namespace Lockethot.Engines.CLI
{
    public class CommandLineAction
    {
        public string Name;
        public ActionWrapperBase Action;

        public CommandLineAction(string name, ActionWrapperBase action)
        {
            Name = name;
            Action = action;
        }
    }
}
