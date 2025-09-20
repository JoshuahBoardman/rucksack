using Rucksack.Types;

namespace Rucksack.Services.Packages
{
    class PackageService
    {
        public List<Package> Packages { get; set; } = new();

        PackageService(List<Package> packages)
        {
            this.Packages = packages;
        }
    }
}
