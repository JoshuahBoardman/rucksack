using System.CommandLine;
using System.IO;

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

            bootstrapCommand.SetAction(parseResult => Handle(parseResult.GetValue(pathArgument)));

            return bootstrapCommand;
        }

        private static void Handle(string pathArg)
        {
            string manifestPath = $"{pathArg}/manifest.json";
            try
            {
                string fileText = File.ReadAllText(manifestPath);
                Console.WriteLine(fileText);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(
                    $"Error: Could not read manifest file at '{manifestPath}'. \n Reason: {ex.Message}"
                );
            }
        }
    }
}
