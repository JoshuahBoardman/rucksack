namespace Rucksack.Types;

class PackageManager
{
    public required string Command { get; set; }
    public required string InstallArgs { get; set; }
    public string? updateArgs { get; set; }
    public string? uninstallArgs { get; set; }

}
