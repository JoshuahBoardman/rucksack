# RuckSack
*Carry your personal developer enviorment everywhere you go and be certain everything you want is in its correct place.*

## TODOs:

**Make JSON schema:**
- How does what is the structure.
- Write Util for accessing JSON data.
- Consider using TOML

**Create application structure:**
- Define how the folders will be distributed for configs, chache, and package database. 

**Build Symlinker class:**
- Is responsible for taking paths and placing configs in the paths defined.
- The linker should also provide utility functions for things like removing files that exist with the same name, or maybe store the ones you deleted in a backup, in case you wanted it.

**TODO: Create Sym Link Manager:**
- Manages what configs were linked, and handles any operations on the linked configs.
- Might be able to make this a singleton.
- Should be able to handle operations like, remove symlinked files and even do things like only remove specific sym links by priority level and maybe even place back here any files that were replaced via rucksack.

**Create Package Installer:**
- Install packages using the package and manager defined in the config.

**Create Package Manager:**
- Manages what packages were installed, and handles any operations on the packages installed.
- Might be able to make this a singleton.
- Should be able to handle operations like, remove packages and even do things like only remove specific packages by priority level and maybe even place back here any files that were replaced via rucksack.

**Create Script Runner:**
- Run scripts at specified timmes (hooks) in the enviorment setup process using the script run.
- Might be able to make this a singleton.

**MAYBE: Create Enviorment/Secret Variable Manager:**
- Be able to store Encrypted values for use in your enviroment as needed. 

**Toolbox Itenerary functionality:**
- Look up what tools you have in your enviorment, what they do, and when you should use them.
- This would simply be built ontop of the package manager and maybe the symlinker functionality.
- The idea of this is that, you always have your tools with you when you use rucksack, 
and it can be nice to be able to quickly look through what tools you have to solve a problem. 

TODO: Make RuckSack start kit (a list of programd that is useful for the adverage developer)

## File Output and Config locations
NOTE: App Structure:
Logs - `$HOME/.local/state/[app]/logs/`
Config - `$HOME/.config/[app]`
Internal data storage - `~/.local/share/[app]/`
