using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockethot.Engines.CLI
{
    public class CommandLineInterpreterData
    {
        public StringBuilder Token = new StringBuilder();
        public bool InString = false;
    }
}
