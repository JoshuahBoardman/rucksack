namespace Rucksack.Types;

class PackageManager
{
    public required string Command { get; set; }
    public required string InstallArgs { get; set; }
    public string? UpdateArgs { get; set; }
    public string? UninstallArgs { get; set; }
    public bool? Sudo { get; set; }

}
