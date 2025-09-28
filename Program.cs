namespace Rucksack;

using System.CommandLine;

class Program
{
    static int Main(string[] args)
    {
        //TODO: Make this handle other formats than just JSON
        string configPath = Environment.GetEnvironmentVariable("RUCKSACK_CONFIG")
                            ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "rucksack", "config.json"); //TODO: Setup to handle windows as well. 

        //NOTE: Rucksack - Root Command
        RootCommand rucksack = new("Bring your developer enviorment everywhere you go.");

        //NOTE: This is how 
        rucksack.Subcommands.Add(Commands.Bootstrap.BootstrapCommand.Build());

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
