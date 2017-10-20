using System.Collections.Generic;

namespace Resources {

    public class Lists {

        #region Files and folders

        public static List<string> vanillaItems_files = new List<string>(new string[]
            {
                "darksouls.exe",

                "dvdbnd0.bdt",
                "dvdbnd0.bhd5",
                "dvdbnd1.bdt",
                "dvdbnd1.bhd5",
                "dvdbnd2.bdt",
                "dvdbnd2.bhd5",
                "dvdbnd3.bdt",
                "dvdbnd3.bhd5",

                "fmodex.dll",
                "fmod_event.dll",
                "steam_api.dll",
                "steam_appid.txt"
            });

        public static List<string> vanillaItems_directories = new List<string>(new string[]
            {
                "movww",
                "readme"
            });



        public static List<string> otherNonVanilla_files = new List<string>(new string[]
           {
                "darksouls.exe.bak",

                "dvdbnd0.bdt.bak",
                "dvdbnd0.bhd5.bak",
                "dvdbnd1.bdt.bak",
                "dvdbnd1.bhd5.bak",
                "dvdbnd2.bdt.bak",
                "dvdbnd2.bhd5.bak",
                "dvdbnd3.bdt.bak",
                "dvdbnd3.bhd5.bak",

                "dvdbnd3.bdt.backup",
                "dvdbnd3.bhd5.backup"
           });

        public static List<string> otherNonVanilla_directories = new List<string>(new string[]
            {
                "dvdbnd0.bhd5.extract",
                "dvdbnd1.bhd5.extract",
                "dvdbnd2.bhd5.extract",
                "dvdbnd3.bhd5.extract",

                "chr",
                "event",
                "map",
                "remo",
                "script",
                "sfx",

                "facegen",
                "font",
                "menu",
                "msg",
                "mtd",
                "obj",
                "other",
                "param",
                "paramdef",
                "parts",
                "shader",
                "sound"
            });



        public static List<string> DSMIitems_files = new List<string>(new string[]
            {
                "dinput8.dll",
                "dsfix.ini",
                "dsfix_readme.txt",
                "dsfix_versions.txt",
                "dsfixkeys.ini",
                "dsfix.log",

                "dsmfix.dll",
                "dsmfix.ini",
                "dsmfix_readme.txt",
                "dsmfixgui.exe",

                "darksoulsmousefix.dll",
                "darksoulsmousefix.ini",
                "darksoulsmousefixgui.exe",
                "darksoulsmousefixreadme.md",
                "darksoulsmousefixreadme.pdf",

                "dspw_changelog.txt",
                "dspw_readme.txt",
                "dspw_version",
                "dspwsteam.ini",
                "msvcp120.dll",
                "msvcr120.dll",

                "dscm.exe",

                "winmm.dll", // FPSfix+
                "fpsfix.ini",

                "d3d9.dll",
                "d3d9_wd.dll",
                "d3d9_sf.dll",
                "log.log",

                "sweetfx_preset.txt",
                "sweetfx_readme.txt",
                "sweetfx_settings.txt",

                "dsfix",
                "sweetfx"
            });

        public static List<string> DSMIitems_directories = new List<string>(new string[]
            {
                "dsfix",
                "dvdbnd3",
                "sweetfx"
            });

        #endregion


        #region GUI items - DSMI Config Tool

        public static List<string> renderRes_Values = new List<string>(new string[]
            {
                "3840x2160",
                "2560x1440",
                "1920x1080",
                "1600x900",
                "1280x720",
                "1024x576",
                "896x504",
                "768x432",
                "640x360",
                "512x288",
                "384x216"
            });

        public static List<string> uiRes_Values = new List<string>(new string[]
            {
                "3840x2160",
                "2560x1440",
                "1920x1080",
                "1600x900",
                "1280x720"
            });

        public static List<string> dofOverrideRes_Values = new List<string>(new string[]
            {
                "360",
                "540",
                "810",
                "1080",
                "2160"
            });

        public static List<string> gamepadButtonsStyle_Values = new List<string>(new string[]
            {
                "Xbox 360 HD",
                "Xbox One",
                "PlayStation 3",
                "PlayStation 4"
            });

        #endregion

    }
}
