using System.Diagnostics;
using Rucksack.Types;

namespace Rucksack.Utils.Command
{
    static public class CommandHelper
    {
        static public CommandResult RunCommand(string command, string arguments)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = command,   // e.g., "apt-get" or "bash"
                    Arguments = arguments,     // e.g., "install -y git"
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            var result = new CommandResult
            {
                ExitCode = process.ExitCode,
                StandardOutput = output,
                StandardError = error
            };

            return result;
        }
    }

}
