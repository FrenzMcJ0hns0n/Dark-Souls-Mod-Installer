using Resources; // Resources.dll
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace DSMI_MainLauncher {

    public partial class MainWindow : Window {

        public static string startDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\";
        public static string sourceDir = Path.GetFullPath(Path.Combine(startDir, @"..\Source\"));

        public string lang;
        public string DATApath;

        public string DSCMpath;
        public string steamPath;


        public void SetLanguage(string lan) {
            // Folder buttons
            button_DATAfolder.ToolTip = Strings.button_DATAfolder_toolTipLanguage(lan);
            button_DSMIsRootfolder.ToolTip = Strings.button_DSMIsRootfolder_toolTipLanguage(lan);
            // Text buttons
            button_play.Content = Strings.button_play_contentLanguage(lan);
            button_gameSettings.Content = Strings.button_gameSettings_contentLanguage(lan);
            button_install.Content = Strings.button_install_contentLanguage(lan);
            button_projectSettings.Content = Strings.button_projectSettings_contentLanguage(lan);
            button_uninstall.Content = Strings.button_uninstall_contentLanguage(lan);
        }

        public MainWindow() {

            if (!(File.Exists(startDir + "Resources.dll"))) {
                MessageBox.Show("Error : File \"Resources.dll\" not found !\n\nPlease check your setup then try again.");
                Environment.Exit(0);
            }

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            if (File.Exists(startDir + "DSMI_settings.txt")) {
                lang = Functions.GetValueFromFile(startDir + "DSMI_settings.txt", "language ", 0);
                SetLanguage(lang);

                DATApath = Functions.ParseDataPathValue(startDir + "DSMI_settings.txt", "dataFolderPath ");

                if (DATApath == "") {
                    MessageBox.Show(Strings.ErrorMsg_wrongDataPath(lang));
                }
                else {

                    if (DATApath.Substring(DATApath.Length - 1) != @"\") {
                        DATApath = DATApath + @"\";
                    }

                    if (File.Exists(DATApath + "fmodex.dll") && File.Exists(DATApath + "fmod_event.dll")) {
                        button_DATAfolder.IsEnabled = true;
                        button_play.IsEnabled = true;
                        button_gameSettings.IsEnabled = true;
                        button_install.IsEnabled = true;
                        button_uninstall.IsEnabled = true;
                    }
                    else {
                        MessageBox.Show(Strings.ErrorMsg_wrongDataPath(lang));
                    }
                }
            }

            SetLanguage(lang);

        }


        #region Button events

        private void button_DATAfolder_Click(object sender, RoutedEventArgs e) {
            Process.Start(DATApath);
        }

        private void button_DSMIsRootfolder_Click(object sender, RoutedEventArgs e) {
            try {
                Process.Start(Path.GetFullPath(Path.Combine(startDir, @"..\")));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_play_Click(object sender, RoutedEventArgs e) {

            int launcherPathOk = 0;
            if (File.Exists(startDir + "LAUNCHER.bat")) {

                if (Functions.ParseLauncherPath(startDir + "LAUNCHER.bat", "start \"\" \"", 0, 1) != "") { launcherPathOk++; }
                if (Functions.ParseLauncherPath(startDir + "LAUNCHER.bat", "start \"\" \"", 1, 19) != "") { launcherPathOk++; }

                if (launcherPathOk == 2) {
                    Process.Start(startDir + "LAUNCHER.bat");
                }
                else {
                    MessageBox.Show(Strings.ErrorMsg_invalidLauncher(lang));
                    CreateLauncher();
                }
            }
            else {
                MessageBox.Show(Strings.Message_noLauncher(lang));
                CreateLauncher();
            }
        }

        private void button_settings_Click(object sender, RoutedEventArgs e) {

            try {
                Process.Start(startDir + "DSMI-ConfigTool.exe");
            }
            catch {
                MessageBox.Show(Strings.ErrorMsg_programNotFound(lang, "DSMI-ConfigTool"));
            }

        }

        private void button_install_Click(object sender, RoutedEventArgs e) {

            string[] elements;
            string file_name;
            string folder_name;
            int counter = 0;


            // GET files within the DATA folder -----

            elements = Directory.GetFiles(DATApath);

            foreach (string file in elements) {
                file_name = new FileInfo(file).Name;
                file_name = file_name.ToLower();

                if (Lists.DSMIitems_files.Contains(file_name)) {
                    counter++;
                }
            }


            // GET directories within the DATA folder -----

            elements = Directory.GetDirectories(DATApath);

            foreach (string folder in elements) {
                folder_name = new DirectoryInfo(folder).Name;
                folder_name = folder_name.ToLower();

                if (Lists.DSMIitems_directories.Contains(folder_name)) {
                    counter++;
                }
            }


            // Ckeck files/folders count -----

            if (counter > 0) {
                MessageBoxResult msgBoxResult = MessageBox.Show(
                    Strings.Warning_installContent(lang), 
                    Strings.Warning_installHeader(lang), 
                    MessageBoxButton.YesNo);

                if (msgBoxResult == MessageBoxResult.Yes) {
                    CallLongRunningMethod_Install();
                }
            }
            else {
                CallLongRunningMethod_Install();
            }

        }

        private void button_projectSettings_Click(object sender, RoutedEventArgs e) {
            try {
                Process.Start(startDir + "DSMI-ProjectSettings.exe"); Environment.Exit(0);
            }
            catch {
                MessageBox.Show(Strings.ErrorMsg_programNotFound(lang, "DSMI Project Settings.exe"));
                Environment.Exit(0);
            }
        }

        private void button_uninstall_Click(object sender, RoutedEventArgs e) {
            try {
                Process.Start(startDir + "DSMI-Un.exe");
            }
            catch {
                MessageBox.Show(Strings.ErrorMsg_programNotFound(lang, "DSMI Un.exe"));
            }
        }

        #endregion


        public void CreateLauncher() {
            string str;

            // DSCM.exe location
            str = Functions.GetDataFolderPathWithRegistry();

            if (File.Exists(str + "DSCM.exe")) {
                DSCMpath = str + "DSCM.exe";
            }

            // Steam.exe location
            str = Functions.GetSteamFolderPathWithRegistry();

            if (File.Exists(str + "Steam.exe")) {
                steamPath = str + "Steam.exe";
            }

            if (File.Exists(DSCMpath) && File.Exists(steamPath)) {
                try {
                    using (StreamWriter sw = new StreamWriter(startDir + "LAUNCHER.bat")) {
                        sw.WriteLine("@echo off");
                        sw.WriteLine("start \"\" \"" + DSCMpath + "\"");
                        sw.WriteLine("timeout /t 1>nul");
                        sw.WriteLine("start \"\" \"" + steamPath + "\" -applaunch 211420");
                    }
                    MessageBox.Show(Strings.Message_launcherCreated(lang));
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }

            }
            else {
                MessageBox.Show(Strings.Message_launcherCreationFailed(lang));

                try {
                    Process.Start(startDir + @"Miscellaneous\LAUNCHER_GENERATOR.bat");
                }
                catch {
                    MessageBox.Show(Strings.ErrorMsg_programNotFound("LAUNCHER GENERATOR", lang));
                }
            }

        }


        #region Installation

        private async void CallLongRunningMethod_Install() {
            await LongRunningMethodAsync_Install();
        }

        private Task LongRunningMethodAsync_Install() {
            return Task.Run(() => Install());
        }

        private void Install() {

            try {
                foreach (string dirPath in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories)) {
                    Directory.CreateDirectory(dirPath.Replace(sourceDir, DATApath));
                }

                foreach (string newPath in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories)) {
                    File.Copy(newPath, newPath.Replace(sourceDir, DATApath), true);
                }

                MessageBox.Show(Strings.Message_installationCompleted(lang));

            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
