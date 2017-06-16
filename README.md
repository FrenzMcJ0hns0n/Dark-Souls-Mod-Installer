# Dark-Souls-Mod-Installer
Dark-Souls-Mod-Installer (DSMI) is a compilation of mods for Dark Souls: Prepare to Die Edition, and some multilingual programs to install and manage them. The aim is to provide a lore-friendly starter pack for people who don't want to spend time installing and configuring files to play decently.

It is advised to use the last, fully-patched Steam version of the game so that all the mods work as intended.


### Installed mods
- DSfix [http://blog.metaclassofnil.com/?tag=dsfix] GitHub : https://github.com/PeterTh/dsfix
- Dark Souls Mouse Fix (DSMfix) [https://www.reddit.com/r/darksouls/comments/3ay9aj/dsmfix_update_for_new_steamworks_patch/]
- Dark Souls Mouse Fix (new fix) [http://www.nexusmods.com/darksouls/mods/1241/?]
- Dark Souls PvP Watchdog (DSPW) [http://www.nexusmods.com/darksouls/mods/849/?]
- Dark Souls Connectivity Mod (DSCM) [http://www.nexusmods.com/darksouls/mods/1047/?]
- FPSFix [http://www.nexusmods.com/darksouls/mods/862/?] GitHub : https://github.com/NullBy7e/FPSFix/blob/master/FPSFix.h
- Dark Souls SweetFX HDR (SweetFX 1.4 + presets) [http://www.nexusmods.com/darksouls/mods/289/?]
- HD Painted Soapstone Signs [http://www.nexusmods.com/darksouls/mods/1161/?]
- Health Bar Usability Tweaks [http://www.nexusmods.com/darksouls/mods/447/?]
- Improved Normal Arrows [http://www.nexusmods.com/darksouls/mods/197/?]
- Optimized Lava Eyesore Fix [http://www.nexusmods.com/darksouls/mods/1025/?]
- PROPER FIX for low res trees bug [http://www.nexusmods.com/darksouls/mods/1109/?]
- Xbox 360 HD Interface Icons [http://www.nexusmods.com/darksouls/mods/171/?]
- Xbox One Icons (from mod UI III) [http://www.nexusmods.com/darksouls/mods/1107/?]
- DualShock 3 Interface Icons [http://www.nexusmods.com/darksouls/mods/728/?]
- Dark Souls Dualshock 4 Interface [http://www.nexusmods.com/darksouls/mods/690/?]


### Optional mods/programs
- All enemies are Gravelord Phantoms [http://www.nexusmods.com/darksouls/mods/1176/?]
- Alternative starting classes [http://www.nexusmods.com/darksouls/mods/1215/?]
- Dark Souls III menu sound effects [http://www.nexusmods.com/darksouls/mods/1195/?]
- Health Bars Usability Tweaks (colorblind version)
- Improved texts [http://www.nexusmods.com/darksouls/mods/1198/?]
- DS-ExeModifier > GitHub : https://github.com/FrenzMcJ0hns0n/DS-ExeModifier


### Prerequisites
- Dark Souls: Prepare to Die Edition (Steam)
- .NET framework 4.5


### How to use it
0) Install Dark Souls: Prepare to Die Edition with Steam
   
[First install of the game ?
Launch it once, to make Steam install some software prerequisites. Once on the main screen, you can exit.]

Create a shortcut for "DSMI\Programs\DSMI-MainLauncher", and put it wherether you want.

1) Run DSMI Main Launcher
2) Click "Project settings" to define the global settings of the project
3) Click "Install mods" to install all DSMI files/folders
4) Click "Settings" to configure the game
5) Click "Play" to run game + DSCM


### Contact
https://www.reddit.com/user/McJ0hns0n/


### Notes
- This still is a work in progress : feedbacks or suggestions are welcome.
- Sean Pesce released a very similar project, see [this link](https://www.reddit.com/r/DarkSoulsMods/comments/64gevf/release_das1_dark_souls_configuration_utility/)

---------------------------------------------------------------------------------------------------------------------------------------

## Programmer guide

This project actually contains 5 distinct projects : 
- DSMI ConfigTool
- DSMI MainLauncher
- DSMI ProjectSettings
- DSMI DSMI-Un-in-st-al-le-r (cheap trick to avoid the Windows message "this program might not have installed correctly")
- Resources

The 4 DSMI ones generate .exe files. "Resources" is designed to hold the common resources and therefore it generates a .dll file. This maybe isn't the best way to organize files, but this is the way I started worked on it, since it is my first substancial project. 

Everything is written in C#, with the WPF technology. For those who aren't used to it, simply look the files MainPage.xaml (design) and MainPaige.xaml.cs (code-behind) of each DSMI projects to get all the interesting parts
