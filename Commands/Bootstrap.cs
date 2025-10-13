using System.CommandLine;
using System.Text.Json;
using System.IO;
using Rucksack.Services.Manifest;
using Rucksack.Services.DotFiles;
using Rucksack.Services.Packages;
using Rucksack.Services.PackageManagement;
using Rucksack.Types;
using Rucksack.Utils.User;
using Rucksack.Utils.Template;
using Rucksack.Utils.Path;

namespace Rucksack.Commands.Bootstrap
{
    static class BootstrapCommand
    {
        //TODO: Handle ToolCommand lifecysle hook/trigger.
        public static Command Build()
        {
            Command bootstrapCommand = new(
            "bootstrap",
            "Setup entire developer if not used under and enviorment scope."
            );

            Argument<string> pathArgument = new("path")
            {
                Description = "Path to the folder Rucksack will bootstrap from.",
                DefaultValueFactory = parseResult =>
                {
                    // TODO: Might want to add aditional 
                    string currentDir = Directory.GetCurrentDirectory();
                    return currentDir;
                }
            };
            bootstrapCommand.Arguments.Add(pathArgument);

            bootstrapCommand.SetAction(parseResult => Handler(parseResult.GetValue(pathArgument)));

            return bootstrapCommand;
        }

        //TODO: COmmands should handle of their arugments themselves not serivces/utils.
        // TODO: Command hanlders should handle errors and services should throw errors
        // - Likely will have an error service.
        private static void Handler(string pathArg)
        {
            var manifestService = new ManifestService(pathArg);
            //TODO: IMPORTANT: Expand all paths on population
            //	- Likley would do this in the setter for the collection or the Load method
            manifestService.Load();

            //TODO: might want to do a diff between manifest and registry for checking for updates and can provide verbose output for differences/what was not added

            //TODO: Check if the file/symlink already exists.
            //TODO: Check if the the symlink is managed by rucksack and is using the rucksack managed config.
            //	- If the file is not managed by ruck sack isntuct the user to pass an argument so that rucksack will replace the link with the link to the correct rucksack source file.
            //	- Allow an argument to be passed to handle storing the previous file or symlink for when packout happens.
            //TODO: Register the file with the registry once the above criteria is achieved.
            // TODO: If link alredy exists, and is not in registry let the user know and communicate the args needed
            foreach (var tool in manifestService.Manifest.Tools)
            {
                var managers = manifestService.Manifest.PackageManagers;

                string dotFilesPath = Path.Combine(pathArg, "configs");
                string dotFileSource = Path.Combine(dotFilesPath, tool.DotFile.Source);

                // TODO: handle passing home argument to RolverHome
                string homePath = UserContextHelper.ResolveHome();
                string expandedTargetPath = PathHelper.ExpandPath(tool.DotFile.Target, homePath);


                //TODO: Check if the package has been installed via the registry
                if (tool.Package != null && managers != null)
                {
                    PackageManagerService.Install(managers, tool.Package);
                }

                var exists = PathHelper.FileExists(expandedTargetPath);
                var isSymlink = PathHelper.IsSymlink(expandedTargetPath);
                var isManagedTool = PathHelper.LinksTo(expandedTargetPath, tool.DotFile.Source);

                // TODO: Update to use the register service.
                var isRegistered = true;

                //TODO: Register package and symlinks with the registry
                if (tool.DotFile != null)
                {
                    if (exists)
                    {
                        if (isSymlink)
                        {
                            if (!isManagedTool)
                            {
                                Console.WriteLine($"Symlink at {expandedTargetPath} doesn’t point to Rucksack source.");
                                return;
                            }

                            if (!isRegistered)
                            {
                                Console.WriteLine($"Symlink exists but isn’t in the registry.");
                                // TODO: registryService.Register(dotFile);
                                return;
                            }

                            //TODO: Relink if arument is passed
                            Console.WriteLine($"Already linked and registered.");
                            return;
                        }

                        Console.WriteLine($"File already exists and is not a symlink.");
                        return;
                    }
                }

                DotFilesService.LinkFile(tool.DotFile, pathArg);
                Console.WriteLine($"Linked {tool.DotFile.Source} → {expandedTargetPath}");
            }

        }
    }
}
