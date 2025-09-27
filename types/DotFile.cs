namespace Rucksack.Types;

class DotFile
{
    public required string Source { get; set; }
    public required string Target { get; set; }
    public required string Type { get; set; } // Make this an enum for file or folder
    public string? Override { get; set; }
}

