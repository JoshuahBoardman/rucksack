//TODO: IMPORTANT: Need to find a way to support different package manager per package depending on enviorment
namespace Rucksack.Services.PackageManagement
{
    using System.Diagnostics;
    using Rucksack.Types;
    using Rucksack.Utils.Template;
    using Rucksack.Utils.Command;

    class PackageManagerService
    {
        public Dictionary<string, PackageManager> PackageManagers { get; set; } = new();

        public PackageManagerService(Dictionary<string, PackageManager> packageManagers)
        {
            this.PackageManagers = packageManagers;
        }

        public void Install(Package package)
        {
            var manager = this.PackageManagers[package.Manager];

            Dictionary<TemplateVariable, string> packageValues = new()
         {
            { TemplateVariable.Package, package.PackageName },
            { TemplateVariable.Version, package.Version }
     };
            string expandedInstallArgs = TemplateHelper.Expand(manager.InstallArgs, packageValues);

            CommandHelper.RunCommand(manager.Command, expandedInstallArgs);

        }

        public void Update(Package package)
        {

        }

        public void Remove(Package package)
        {

        }

    }
}
