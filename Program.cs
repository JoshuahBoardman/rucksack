// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// TODO: Make JSON schema
// - How does what is the structure.
// - Write Util for accessing JSON data.
// - Consider using TOML

// TODO: Create application structure
// - Define how the folders will be distributed for configs, chache, and package database. 

// TODO: Build Symlinker class
// - Is responsible for taking paths and placing configs in the paths defined.
// - The linker should also provide utility functions for things like removing files that exist with the same name, or maybe store the ones you deleted in a backup, in case you wanted it.

//TODO: Create Sym Link Manager:
// - Manages what configs were linked, and handles any operations on the linked configs.
// - Might be able to make this a singleton.
// - Should be able to handle operations like, remove symlinked files and even do things like only remove specific sym links by priority level and maybe even place back here any files that were replaced via rucksack.

//TODO: Create Package Installer:
// - Install packages using the package and manager defined in the config.

// TODO: Create Package Manager:
// - Manages what packages were installed, and handles any operations on the packages installed.
// - Might be able to make this a singleton.
// - Should be able to handle operations like, remove packages and even do things like only remove specific packages by priority level and maybe even place back here any files that were replaced via rucksack.

// TODO: Create Script Runner:
// - Run scripts at specified timmes (hooks) in the enviorment setup process using the script run.
// - Might be able to make this a singleton.

// MAYBE: Create Enviorment/Secret Variable Manager:
// - Be able to store Encrypted values for use in your enviroment as needed. 
