namespace Rucksack.Types;

class Manifest
{
    public Dictionary<string, PackageManager>? PackageManagers { get; set; }
    public List<Tool>? Tools { get; set; }
}
