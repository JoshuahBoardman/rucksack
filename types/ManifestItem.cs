namespace Rucksack.Types;

class ManifestItem
{
    public required string Name { get; set; }
    public required string Priority { get; set; } //Make this an enum
    public Package? Package { get; set; }
    public DotFile? DotFile { get; set; }
}
