namespace Rucksack.Types;

class Package
{
    public required string PackageName { set; get; }
    public required string Manager { set; get; }
    public string? Version { set; get; }
}
