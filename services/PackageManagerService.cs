using Rucksack.Types;

namespace Rucksack.Services.PackageManagement
{
    class PackageManagerService
    {
        public Dictionary<string, PackageManager> PackageManagers { get; set; } = new();

        PackageManagerService(Dictionary<string, PackageManager> packageManagers)
        {
            this.PackageManagers = packageManagers;
        }
    }

}
