using System.CommandLine;
using System.Text.Json;
using System.IO;
using Rucksack.Services.Manifest;

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
        // 3. Use the manifest object to 
        private static void Handler(string pathArg)
        {
            var manifest = new ManifestService(pathArg);
            manifest.Load();
        }
    }
}
