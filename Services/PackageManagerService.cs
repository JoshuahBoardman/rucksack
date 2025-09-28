//TODO: IMPORTANT: Need to find a way to support different package manager per package depending on enviorment
namespace Rucksack.Services.PackageManagement
{
    using System.Diagnostics;
    using Rucksack.Types;
    using Rucksack.Utils.Template;
    using Rucksack.Utils.Command;

    static class PackageManagerService
    {
        /*public Dictionary<string, PackageManager> PackageManagers { get; set; } = new();

        public PackageManagerService(Dictionary<string, PackageManager> packageManagers)
        {
            this.PackageManagers = packageManagers;
        }*/

        static public void Install(Dictionary<string, PackageManager> managers, Package package)
        {
            var manager = managers[package.Manager];

            Dictionary<TemplateVariable, string> packageValues = new()
         {
            { TemplateVariable.Package, package.PackageName },
            { TemplateVariable.Version, package.Version }
     };
            string expandedInstallArgs = TemplateHelper.Expand(manager.InstallArgs, packageValues);

            CommandHelper.RunCommand(manager.Command, expandedInstallArgs);

        }

        static public void Update(Package package)
        {

        }

        static public void Remove(Package package)
        {

        }

    }
}
