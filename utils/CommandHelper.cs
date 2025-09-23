using System.Diagnostics;

namespace Rucksack.Utils.Command
{
    static public class CommandHelper
    {
        static public void RunCommand(string command, string arguments)
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

            if (!string.IsNullOrEmpty(output))
                Console.WriteLine(output);

            if (!string.IsNullOrEmpty(error))
                Console.Error.WriteLine(error);
        }
    }

}
