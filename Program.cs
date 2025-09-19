namespace rucksack;

using System.CommandLine;

class Program
{
    static int Main(string[] args)
    {
        //TODO: Make this handle other formats than just JSON
        string configPath = Environment.GetEnvironmentVariable("RUCKSACK_CONFIG")
                            ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "rucksack", "config.json"); //TODO: Setup to handle windows as well. 

        //TODO: Make a manifestPath property.

        //TODO: make rucksack class.

        //TODO: make command namespace and add commands a files in the command directory

        //NOTE: Rucksack - Root Command
        RootCommand rucksack = new("Bring your developer enviorment everywhere you go.");

        //NOTE: dotfiles - Command Group 
        Command dotFilesCommand = new("dotfiles", "Manage your enviorment dotFiles.");
        rucksack.Subcommands.Add(dotFilesCommand);

        //NOTE: Config - Action Command 
        Command manifestCommand = new("manifest", "Returns all a list of dotFiles managed under rucksack."); //TODO: Might be worth making this recursive on all command groups. 
        dotFilesCommand.Subcommands.Add(manifestCommand);

        //NOTE: Config - Manifest Options 
        Option<bool> verboseOption = new("--verbose")
        {
            Description = "Increases the amount of information provided from the manifest",
        };
        manifestCommand.Options.Add(verboseOption);


        // NOTE: Config - Set actions for leaf commands
        manifestCommand.SetAction(parseResult => ReadConfig(
            configPath,
                parseResult.GetValue(verboseOption)
        ));

        //NOTE: Package - Command Group 
        Command packageCommand = new("packages", "Manage your enviorment packages.");
        rucksack.Subcommands.Add(packageCommand);

        //NOTE: All - Command Group 
        Command allCommand = new("all", "Manage everything in your enviorment at the same time.");
        rucksack.Subcommands.Add(allCommand);

        return rucksack.Parse(args).Invoke();
    }

    //TODO: Rewrite this so that it pulls specific data about the command Group and only gives minimal data unless verbose is specified.
    internal static void ReadConfig(string configPath, bool verbose)
    {

        var configFile = File.ReadAllText(configPath);

        Console.WriteLine(configFile);
        Console.WriteLine($"Verbose {verbose}");
    }

}
