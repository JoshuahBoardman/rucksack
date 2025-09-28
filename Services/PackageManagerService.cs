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
                [TemplateVariable.Version] = package.Version
            };

            string expandedInstallArgs = TemplateHelper.Expand(manager.InstallArgs, packageValues);

            var result = CommandHelper.RunCommand(manager.Command, expandedInstallArgs);

            if (!result.Success)
            {
                throw new InvalidOperationException(
                    $"Package installation failed: {package.PackageName} via {package.Manager}\n" +
                    $"Error: {result.StandardError}");
            }

            Console.WriteLine(result.StandardOutput);
        }

        static public void Update(Package package)
        {

        }

        static public void Remove(Package package)
        {

        }

    }
}
