namespace Rucksack.Types;

/*
"apt": {
	"installCommand": "apt-get install -y {package}@{version}",
	"updateCommand": "apt-get update && apt-get upgrade -y {package}"
},
*/

/*class PackageManager
{
    public string InstallCommand { set; get; }
    public string UpdateCommand { set; get; }
}*/

class PackageManager
{
    public string Command { get; set; }
    public string InstallArgs { get; set; }
    public string? updateArgs { get; set; }
    public string? uninstallArgs { get; set; }

}
