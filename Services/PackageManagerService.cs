//TODO: IMPORTANT: Need to find a way to support different package manager per package depending on enviorment
namespace Rucksack.Services.PackageManagement
{
    using System.Diagnostics;
    using Rucksack.Types;
    using Rucksack.Utils.Template;
    using Rucksack.Utils.Command;

    static class PackageManagerService
    {
        static public void Install(Dictionary<string, PackageManager> managers, Package package)
        {
            if (!managers.ContainsKey(package.Manager))
            {
                throw new InvalidOperationException($"No package manager defined for {package.Manager}.");
            }

            var manager = managers[package.Manager];

            var packageValues = new Dictionary<TemplateVariable, string>
            {
                [TemplateVariable.Package] = package.PackageName,
            };

            if (!string.IsNullOrEmpty(package.Version))
            {
                packageValues.Add(TemplateVariable.Version, package.Version);
            }

            string expandedInstallArgs = TemplateHelper.Expand(manager.InstallArgs, packageValues);

            var (command, args) = manager.Sudo == true
                ? ("sudo", $"{manager.Command} {expandedInstallArgs}")
                : (manager.Command, expandedInstallArgs);

            //TODO: Run only for verbose flag
            //TODO: Standardize logging via logging service
            if (manager.Sudo == true)
            {
                Console.WriteLine($"[INFO] The {manager.Command} manifest entry has sudo set to true");
            }

            var result = CommandHelper.RunCommand(command, args);

            if (!result.Success)
            {
                var errMsg = $"Package installation failed: {package.PackageName} via {package.Manager}\n" +
                             $"Error: {result.StandardError}";

                if (manager.Sudo != true)
                {
                    errMsg += "\nHint: this command may require elevated permissions. Set `sudo: true` in the manifest.";
                }

                throw new InvalidOperationException(errMsg);
            }

            Console.WriteLine($"Installed {package.PackageName} {(string.IsNullOrEmpty(package.Version) ? "" : $"version {package.Version} ")}via {package.Manager}");
        }

        static public void Update(Package package)
        {

        }

        static public void Remove(Package package)
        {

        }

    }
}
