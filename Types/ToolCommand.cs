namespace Rucksack.Types;

class ToolCommand
{
    public required string CommandString { get; set; }
    public bool RunAsSudo { get; set; } = false;
    public bool Optional { get; set; } = false;
    public CommandTrigger Trigger { get; set; } = CommandTrigger.Manual;
}

// Represents the lifecycle phase or trigger for the command
enum CommandTrigger
{
    OnBootstrap,  // Runs once after initial installation
    OnUpdate,     // Runs after an update
    OnRemove,     // Runs before uninstall/removal
    OnPackup,     // Runs when cleaning up all tools
    Manual        // User-triggered commands
}
