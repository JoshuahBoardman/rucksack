namespace Rucksack.Types;

/*
"apt": {
	"installCommand": "apt-get install -y {package}@{version}",
	"updateCommand": "apt-get update && apt-get upgrade -y {package}"
},
*/

class PackageManager
{
    public string InstallCommand { set; get; }
    public string UpdateCommand { set; get; }

}
