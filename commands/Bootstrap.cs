using System.CommandLine;
using System.Text.Json;
using System.IO;
using Rucksack.Services.Manifest;
using Rucksack.Services.DotFiles;
using Rucksack.Services.Packages;
using Rucksack.Services.PackageManagement;
using Rucksack.Types;

namespace Rucksack.Commands.Bootstrap
{
    static class BootstrapCommand
    {
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

        private static void Handler(string pathArg)
        {
            var manifestService = new ManifestService(pathArg);
            manifestService.Load();

            var packageManagerService = new PackageManagerService(manifestService.Manifest.PackageManagers);

            foreach (var manifestItem in manifestService.Manifest.ManifestItems)
            {
                if (manifestItem.DotFile != null)
                {
                    DotFilesService.LinkFile(manifestItem.DotFile, pathArg);
                }

                if (manifestItem.Package != null)
                {
                    packageManagerService.Install(manifestItem.Package);
                }
            }
        }
    }
}
