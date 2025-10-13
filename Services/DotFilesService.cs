namespace Rucksack.Services.DotFiles
{
    using System.IO;
    using Rucksack.Types;
    using Rucksack.Utils.Path;
    using Rucksack.Utils.User;

    static class DotFilesService
    {
        //TODO: Refactor to only handle the linking of the file.
        static public void LinkFile(DotFile dotFile, string sourcePath)
        {
            string dotFilesPath = Path.Combine(sourcePath, "configs");
            string dotFileSource = Path.Combine(dotFilesPath, dotFile.Source);

            // TODO: handle passing home argument to RolverHome
            string homePath = UserContextHelper.ResolveHome();
            string expandedTargetPath = PathHelper.ExpandPath(dotFile.Target, homePath);

            //TODO: Handle reruns to not link if file/folder are already linked and relink if arg is passed
            //TODO: Verify if the file was added to the registry
            //	- If link alredy exists, and is not in registry let the user know and communicate the 
            //		args needed

            // TODO: check to see if parts of the path leading to the dotFile dont exist and create them.
            // - Make a path walking function in pathhelper
            try
            {
                //TODO: make a Type enum
                if (Directory.Exists(dotFileSource) && dotFile.Type == "folder")
                {
                    Directory.CreateSymbolicLink(expandedTargetPath, dotFileSource);
                }
                else if (File.Exists(dotFileSource) && dotFile.Type == "file")
                {
                    File.CreateSymbolicLink(expandedTargetPath, dotFileSource);
                }
                else
                {
                    Console.WriteLine($"Source type does not match manifest type for {dotFileSource}");
                }

                Console.WriteLine($"Sym Linked: {dotFile.Source}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to symlink file.\nSource: {sourcePath}\nTarget: {dotFile.Target}\nReason: {ex.Message}", ex);
            }
        }
    }
}
