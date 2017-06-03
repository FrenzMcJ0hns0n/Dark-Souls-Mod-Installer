using Resources; // Resources.dll
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace DSMI_Un_in_st_al_le_r {

    public partial class MainWindow : Window {

        public static string startDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\";

        public string DATApath;
        public string lang;

        public string name;
        public int file_counter = 0;
        public int dir_counter = 0;


        public void SetLanguage(string lan) {
            // GroupBox
            groupBox_UninstallOptions.Header = Strings.groupBox_UninstallOptions_headerLanguage(lan);
            // RadioButtons
            radioButton_uninstallDsmiFiles.Content = Strings.radioButton_uninstallDsmiFiles_contentLanguage(lan);
            radioButton_uninstallDsmiFiles.ToolTip = Strings.radioButton_uninstallDsmiFiles_toolTipLanguage(lan);
            radioButton_uninstallMostElements.Content = Strings.radioButton_uninstallMostElements_contentLanguage(lan);
            radioButton_uninstallMostElements.ToolTip = Strings.radioButton_uninstallMostElements_toolTipLanguage(lan);
            radioButton_uninstallAllContent.Content = Strings.radioButton_uninstallAllContent_contentLanguage(lan);
            radioButton_uninstallAllContent.ToolTip = Strings.radioButton_uninstallAllContent_toolTipLanguage(lan);
            // Apply button
            button_proceed.Content = Strings.button_proceed_contentLanguage(lan);

            switch (lan) {
                case "fr":
                    radioButton_uninstallDsmiFiles.Margin = new Thickness(65, 70, 0, 0);
                    radioButton_uninstallMostElements.Margin = new Thickness(65, 93, 0, 0);
                    radioButton_uninstallAllContent.Margin = new Thickness(65, 116, 0, 0);
                    break;
                case "sp":
                    radioButton_uninstallDsmiFiles.Margin = new Thickness(62, 70, 0, 0);
                    radioButton_uninstallMostElements.Margin = new Thickness(62, 93, 0, 0);
                    radioButton_uninstallAllContent.Margin = new Thickness(62, 116, 0, 0);
                    break;
            }
        }

        public MainWindow() {
            if (!(File.Exists(startDir + "Resources.dll"))) {
                MessageBox.Show("Error : File \"Resources.dll\" not found !\n\nPlease check your setup then try again.");
                Environment.Exit(0);
            }
            InitializeComponent();

            if (!(File.Exists(startDir + @"\DSMI_settings.txt"))) {
                MessageBox.Show(Strings.ErrorMsg_projectSettingsFileNotFound(lang));
                Environment.Exit(0);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            lang = Functions.GetValueFromFile(startDir + @"\DSMI_settings.txt", "language", 0);
            SetLanguage(lang);

            DATApath = Functions.ParseDataPathValue(startDir + @"\DSMI_settings.txt", "dataFolderPath");
            if (DATApath == "") {
                MessageBox.Show(Strings.ErrorMsg_invalidDataPath(lang));
                Environment.Exit(0);
            }
            else if (DATApath.Substring(DATApath.Length - 1) != @"\") {
                DATApath = DATApath + @"\";
            }
        }

        private void button_proceed_Click(object sender, RoutedEventArgs e) {


            // Uninstall DSMI items -----

            if (radioButton_uninstallDsmiFiles.IsChecked == true) {
                try {
                    uninstallDsmiFiles();
                }
                catch {
                    MessageBox.Show(Strings.ErrorMsg_errorWhileUninstalling(lang));
                }
            }


            // Uninstall most items -----

            else if (radioButton_uninstallMostElements.IsChecked == true) {
                try {
                    uninstallMostElements();
                }
                catch {
                    MessageBox.Show(Strings.ErrorMsg_errorWhileUninstalling(lang));
                }
            }


            // Uninstall all items -----

            else if (radioButton_uninstallAllContent.IsChecked == true) {
                MessageBoxResult msgBoxResult = MessageBox.Show(Strings.Warning_uninstallAllContent(lang), 
                                                                Strings.Warning_uninstallAllHeader(lang), 
                                                                MessageBoxButton.YesNo);

                if (msgBoxResult == MessageBoxResult.Yes) {
                    try {
                        uninstallAllElements();
                    }
                    catch {
                        MessageBox.Show(Strings.ErrorMsg_errorWhileUninstalling(lang));
                    }
                }
            }


            // None have been chosen -----

            else {
                MessageBox.Show(Strings.ErrorMsg_noOptionsSelected(lang));
            }

        }


        public void uninstallDsmiFiles() {

            string[] filePaths = Directory.GetFiles(DATApath);
            foreach (string filePath in filePaths) {
                name = new FileInfo(filePath).Name;
                name = name.ToLower();

                if ((name == "d3d9.dll") ||
                    (name == "d3d9_wd.dll") ||
                    (name == "d3d9_sf.dll") ||
                    (name == "log.log") ||

                    (name == "dinput8.dll") ||
                    (name == "dsfix.ini") ||
                    (name == "dsfix_readme.txt") ||
                    (name == "dsfix_versions.txt") ||
                    (name == "dsfixkeys.ini") ||
                    (name == "dsfix.log") ||

                    (name == "dscm.exe") ||

                    (name == "dsmfix.dll") ||
                    (name == "dsmfix.ini") ||
                    (name == "dsmfix_readme.txt") ||
                    (name == "dsmfixgui.exe") ||

                    (name == "darksoulsmousefix.dll") ||
                    (name == "darksoulsmousefix.ini") ||
                    (name == "darksoulsmousefixgui.exe") ||
                    (name == "darksoulsmousefixreadme.md") ||
                    (name == "darksoulsmousefixreadme.pdf") ||

                    (name == "dspw_changelog.txt") ||
                    (name == "dspw_readme.txt") ||
                    (name == "dspw_version") ||
                    (name == "dspwsteam.ini") ||
                    (name == "msvcp120.dll") ||
                    (name == "msvcr120.dll") ||

                    (name == "fpsfix.dll") ||
                    (name == "fpsfix.ini") ||

                    (name == "sweetfx_preset.txt") ||
                    (name == "sweetfx_readme.txt") ||
                    (name == "sweetfx_settings.txt")) {
                    file_counter++;
                    File.Delete(filePath);
                }
            }

            string[] dirPaths = Directory.GetDirectories(DATApath);
            foreach (string dirPath in dirPaths) {
                name = new DirectoryInfo(dirPath).Name;
                name = name.ToLower();

                if ((name == "dsfix") ||
                    (name == "sweetfx")) {
                    dir_counter++;
                    Directory.Delete(dirPath, true);
                }
            }

            if ((file_counter > 0) || (dir_counter > 0)) {
                MessageBox.Show(Strings.Message_uninstalledElements(file_counter, dir_counter, lang));
                Environment.Exit(0);
            }
            else {
                MessageBox.Show(Strings.ErrorMsg_nothingToUninstall(lang));
            }

        }

        public void uninstallMostElements() {

            string[] filePaths = Directory.GetFiles(DATApath);
            foreach (string filePath in filePaths) {
                name = new FileInfo(filePath).Name;
                name = name.ToLower();

                if ((name != "darksouls.exe") &&
                    (name != "darksouls.exe.bak") &&

                    (name != "dvdbnd0.bdt") &&
                    (name != "dvdbnd0.bdt.bak") &&
                    (name != "dvdbnd0.bhd5") &&
                    (name != "dvdbnd0.bhd5.bak") &&
                    (name != "dvdbnd1.bdt") &&
                    (name != "dvdbnd1.bdt.bak") &&
                    (name != "dvdbnd1.bhd5") &&
                    (name != "dvdbnd1.bhd5.bak") &&
                    (name != "dvdbnd2.bdt") &&
                    (name != "dvdbnd2.bdt.bak") &&
                    (name != "dvdbnd2.bhd5") &&
                    (name != "dvdbnd2.bhd5.bak") &&
                    (name != "dvdbnd3.bdt") &&
                    (name != "dvdbnd3.bdt.bak") &&
                    (name != "dvdbnd3.bhd5") &&
                    (name != "dvdbnd3.bhd5.bak") &&

                    (name != "fmodex.dll") &&
                    (name != "fmod_event.dll") &&
                    (name != "steam_api.dll") &&
                    (name != "steam_appid.txt")) {
                    file_counter++;
                    File.Delete(filePath);
                }
            }

            string[] dirPaths = Directory.GetDirectories(DATApath);
            foreach (string dirPath in dirPaths) {
                name = new DirectoryInfo(dirPath).Name;
                name = name.ToLower();

                if ((name != "movww") &&
                    (name != "readme") &&

                    (name != "dvdbnd0.bhd5.extract") &&
                    (name != "dvdbnd1.bhd5.extract") &&
                    (name != "dvdbnd2.bhd5.extract") &&
                    (name != "dvdbnd3.bhd5.extract") &&

                    (name != "chr") &&
                    (name != "event") &&
                    (name != "map") &&
                    (name != "remo") &&
                    (name != "script") &&
                    (name != "sfx") &&

                    (name != "facegen") &&
                    (name != "font") &&
                    (name != "menu") &&
                    (name != "msg") &&
                    (name != "mtd") &&
                    (name != "obj") &&
                    (name != "other") &&
                    (name != "param") &&
                    (name != "paramdef") &&
                    (name != "parts") &&
                    (name != "shader") &&
                    (name != "sound")) {
                    dir_counter++;
                    Directory.Delete(dirPath, true);
                }
            }

            if ((file_counter > 0) || (dir_counter > 0)) {
                MessageBox.Show(Strings.Message_uninstalledElements(file_counter, dir_counter, lang));
                Environment.Exit(0);
            }
            else {
                MessageBox.Show(Strings.ErrorMsg_nothingToUninstall(lang));
            }

        }

        public void uninstallAllElements() {

            string[] filePaths = Directory.GetFiles(DATApath);
            foreach (string filePath in filePaths) {
                name = new FileInfo(filePath).Name;
                name = name.ToLower();

                if ((name != "darksouls.exe") &&
                    (name != "darksouls.exe.bak") &&

                    (name != "dvdbnd0.bdt") &&
                    (name != "dvdbnd0.bhd5") &&
                    (name != "dvdbnd1.bdt") &&
                    (name != "dvdbnd1.bhd5") &&
                    (name != "dvdbnd2.bdt") &&
                    (name != "dvdbnd2.bhd5") &&
                    (name != "dvdbnd3.bdt") &&
                    (name != "dvdbnd3.bhd5") &&

                    (name != "fmodex.dll") &&
                    (name != "fmod_event.dll") &&
                    (name != "steam_api.dll") &&
                    (name != "steam_appid.txt")) {
                    file_counter++;
                    File.Delete(filePath);
                }
            }

            string[] dirPaths = Directory.GetDirectories(DATApath);
            foreach (string dirPath in dirPaths) {
                name = new DirectoryInfo(dirPath).Name;
                name = name.ToLower();

                if ((name != "movww") &&
                    (name != "readme")) {
                    dir_counter++;
                    Directory.Delete(dirPath, true);
                }
            }

            if ((file_counter > 0) || (dir_counter > 0)) {
                MessageBox.Show(Strings.Message_uninstalledElements(file_counter, dir_counter, lang));
                Environment.Exit(0);
            }
            else {
                MessageBox.Show(Strings.ErrorMsg_nothingToUninstall(lang));
            }

        }

    }
}
