using System.Diagnostics;
using Rucksack.Types;
using System.Text;

namespace Rucksack.Utils.Command
{
    static public class CommandHelper
    {
        public static CommandResult RunCommand(string command, string arguments)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = command,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var splitArgs = SplitArguments(arguments);

            foreach (var arg in splitArgs)
            {
                startInfo.ArgumentList.Add(arg);
            }

            using var process = new Process
            {
                StartInfo = startInfo
            };

            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Failed to start command '{command}' with arguments '{arguments}'. " +
                    "Make sure the executable exists and is in your PATH.", ex);
            }

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            return new CommandResult
            {
                ExitCode = process.ExitCode,
                StandardOutput = output,
                StandardError = error
            };
        }

        public static IEnumerable<string> SplitArguments(string args)
        {
            var result = new List<string>();
            var currentArg = new StringBuilder();
            bool inQuotes = false;

            foreach (char c in args)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (char.IsWhiteSpace(c) && !inQuotes)
                {
                    if (currentArg.Length > 0)
                    {
                        result.Add(currentArg.ToString());
                        currentArg.Clear();
                    }
                }
                else
                {
                    currentArg.Append(c);
                }
            }

            if (currentArg.Length > 0)
                result.Add(currentArg.ToString());

            return result;
        }
    }
}
