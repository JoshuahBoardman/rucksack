namespace Rucksack.Types;

/*  DotFile Example
{
"name": ".zshrc",
"target": "~/.zshrc",
"priority": "high",
"override": "hard"
}*/

class DotFile
{
    public string Name { set; get; }
    public string Targets { set; get; }
    public string Priority { set; get; } //TODO: Make this an enum of hight, medium, low
    public string? Override { set; get; }
}

