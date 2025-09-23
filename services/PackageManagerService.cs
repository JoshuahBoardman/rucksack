using System.Diagnostics;
using Rucksack.Types;
using Rucksack.Utils.Template;
using Rucksack.Utils.Command;

//TODO: IMPORTANT: I must figure out a solution to being able to corispond a package to 
//multiple possible package managers with the correct package name.
namespace Rucksack.Services.PackageManagement
{
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
            { TemplateVariable.Package, package.Name },
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
