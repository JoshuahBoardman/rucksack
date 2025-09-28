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

        // TODO: Command hanlders should handle errors and services should throw errors
        // - Likely will have an error service.
        private static void Handler(string pathArg)
        {
            var manifestService = new ManifestService(pathArg);
            manifestService.Load();

            foreach (var tool in manifestService.Manifest.Tools)
            {
                if (tool.DotFile != null)
                {
                    DotFilesService.LinkFile(tool.DotFile, pathArg);
                }

                var managers = manifestService.Manifest.PackageManagers;

                if (tool.Package != null && managers != null)
                {
                    PackageManagerService.Install(managers, tool.Package);
                }
            }
        }
    }
}
