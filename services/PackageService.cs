using Rucksack.Types;
using Rucksack.Services.PackageManagement;

namespace Rucksack.Services.Packages
{
    class PackageService
    {
        public List<Package> Packages { get; set; } = new();

        public PackageService(List<Package> packages)
        {
            this.Packages = packages;
        }
    }
}
