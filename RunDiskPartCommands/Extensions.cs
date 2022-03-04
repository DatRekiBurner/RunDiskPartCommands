using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunDiskPartCommands
{
    internal static class Extensions
    {
        internal static void RunCommand(this Process process, string command)
        {
            process.StandardInput.WriteLine(command);
        }
    }
}
