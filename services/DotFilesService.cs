namespace Rucksack.Services.DotFiles
{
    using System.IO;
    using Rucksack.Types;
    using Rucksack.Utils.Path;

    static class DotFilesService
    {

        //TODO: Think about the correct way to supply sourcePath here
        static public void LinkAllFiles(List<DotFile> dotFiles, string sourcePath)
        {
            string dotFilesPath = $"{sourcePath}/configs";

            foreach (var dotFile in dotFiles)
            {
                string expandedTargetPath = PathHelper.ExpandPath(dotFile.Target);

                try
                {
                    string dotFileSource = $"{dotFilesPath}/{dotFile.Source}";
                    File.CreateSymbolicLink(expandedTargetPath, dotFileSource);

                    //TODO: Register these links with the registry.

                    //TODO: Remove or improve this
                    Console.WriteLine($"Sym Linked: {dotFile.Source}");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Failed to symlink file.\n source: {sourcePath} \n target: {dotFile.Target} \n reason: {ex}");

                }
            }
        }

        static public void LinkFile(DotFile dotFile, string sourcePath)
        {
            string dotFilesPath = $"{sourcePath}/configs";

            string expandedTargetPath = PathHelper.ExpandPath(dotFile.Target);

            try
            {
                string dotFileSource = $"{dotFilesPath}/{dotFile.Source}";
                File.CreateSymbolicLink(expandedTargetPath, dotFileSource);

                //TODO: Register these links with the registry.

                //TODO: Remove or improve this
                Console.WriteLine($"Sym Linked: {dotFile.Source}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to symlink file.\n source: {sourcePath} \n target: {dotFile.Target} \n reason: {ex}");

            }
        }
    }
}
