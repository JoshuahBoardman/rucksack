namespace Rucksack.Types;

/*  Package example
 {
	"name": "git",
	"manager": "apt",
	"version": "latest",
	"priority": "high"
}
*/

class Package
{
    public string Name { set; get; }
    public string Manager { set; get; }
    public string Version { set; get; }
    public string Priority { set; get; } //TODO: Create Priority enum for High, Medium, Low.
}
