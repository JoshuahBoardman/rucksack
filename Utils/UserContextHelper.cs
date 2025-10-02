namespace Rucksack.Utils.User
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    static class UserContextHelper
    {
        public static string ResolveHome(string overrideHome = null)
        {
            if (!string.IsNullOrWhiteSpace(overrideHome))
            {
                return Path.GetFullPath(overrideHome);
            }

            string sudoUser = Environment.GetEnvironmentVariable("SUDO_USER");
            if (!string.IsNullOrEmpty(sudoUser) && !RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Checks linux vs mac: /home/<user> or /Users/<user> on macOS
                string basePath = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "/Users" : "/home";
                return Path.Combine(basePath, sudoUser);
            }

            // Tries to fall back to HOME env first for linux/mac
            string home = Environment.GetEnvironmentVariable("HOME");

            if (string.IsNullOrEmpty(home))
            {
                home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            if (string.IsNullOrEmpty(home))
            {
                throw new InvalidOperationException("Could not resolve user home directory.");
            }

            return home;
        }
    }
}
