namespace Rucksack.Types;

class Manifest
{
    public Dictionary<string, PackageManager>? PackageManagers { get; set; }
    public List<ManifestItem>? ManifestItems { get; set; }
}
