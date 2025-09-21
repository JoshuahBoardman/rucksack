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

        // TODO: Handler method:
        // 1. Get file.
        // 2. Convert file json into a manifest object.
        // 3. Use the manifest object to create instances of the Package, DotFiles, and PackageManager services.
        // 4. Use the DotFilesService, PackageService and PackageMangerServices to setup the enviorment.
        // 5. Save everything setup via bootstrap to the registry using the RegistryService.
        // 6. Handle any bootstrap options.
        private static void Handler(string pathArg)
        {
            var manifestService = new ManifestService(pathArg);
            manifestService.Load();

            var dotFilesService = new DotFilesService(manifestService.Manifest.DotFiles);
            dotFilesService.LinkFiles(pathArg);

            //TODO: Install packages
            //var packageService = new PackageService(manifestService.Manifest.Packages);

        }
    }
}
