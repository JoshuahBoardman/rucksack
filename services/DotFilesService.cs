using System.IO;
using Rucksack.Types;
using Rucksack.Utils.Path;

namespace Rucksack.Services.DotFiles
{
    class DotFilesService
    {
        public List<DotFile> DotFiles { get; set; } = new();

        public DotFilesService(List<DotFile> dotFiles)
        {
            this.DotFiles = dotFiles;
        }

        //TODO: Think about the correct way to supply sourcePath here
        public void LinkFiles(string sourcePath)
        {
            var dotFiles = this.DotFiles;

            string dotFilesPath = $"{sourcePath}/configs";

            foreach (DotFile dotFile in dotFiles)
            {
                string expandedTargetPath = PathHelper.ExpandPath(dotFile.Target);

                try
                {
                    string dotFileSource = $"{dotFilesPath}/{dotFile.Name}";
                    File.CreateSymbolicLink(expandedTargetPath, dotFileSource);

                    //TODO: Register these links with the registry.

                    //TODO: Remove or improve this
                    Console.WriteLine($"Sym Linked: {dotFile.Name}");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Failed to symlink file.\n source: {sourcePath} \n target: {dotFile.Target} \n reason: {ex}");

                }
            }


        }
    }
}
