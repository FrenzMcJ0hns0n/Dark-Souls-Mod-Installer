using Resources; // Resources.dll
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace DSMI_MainLauncher {

    public partial class Uninstaller : Window {

        // TODO : Code refactoring !

        public static string startDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\";

        public string DATApath;
        public string lang;

        public string name;
        public int fileCounter = 0;
        public int dirCounter = 0;

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

        public Uninstaller() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            lang = Functions.GetValueFromFile(startDir + @"\DSMI_settings.txt", "language", 0);
            SetLanguage(lang);

            DATApath = Functions.ParseDataPathValue(startDir + @"\DSMI_settings.txt", "dataFolderPath");

            if (DATApath == "") {
                MessageBox.Show(Strings.ErrorMsg_invalidDataPath(lang));
                Close();
            } else if (DATApath.Substring(DATApath.Length - 1) != @"\") {
                DATApath = DATApath + @"\";
            }
        }

        private void button_proceed_Click(object sender, RoutedEventArgs e) {

            // Uninstall DSMI items -----
            if (radioButton_uninstallDsmiFiles.IsChecked == true) {
                try {
                    uninstallDsmiFiles();
                } catch {
                    MessageBox.Show(Strings.ErrorMsg_errorWhileUninstalling(lang));
                }
            }

            // Uninstall most items -----
            else if (radioButton_uninstallMostElements.IsChecked == true) {
                try {
                    uninstallMostElements();
                } catch {
                    MessageBox.Show(Strings.ErrorMsg_errorWhileUninstalling(lang));
                }
            }

            // Uninstall all items -----
            else if (radioButton_uninstallAllContent.IsChecked == true) {
                MessageBoxResult msgBoxResult = MessageBox.Show(
                    Strings.Warning_uninstallAllContent(lang),
                    Strings.Warning_uninstallAllHeader(lang),
                    MessageBoxButton.YesNo);

                if (msgBoxResult == MessageBoxResult.Yes) {
                    try {
                        uninstallAllElements();
                    } catch {
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

            // Deleting files -----
            string[] filePaths = Directory.GetFiles(DATApath);
            foreach (string filePath in filePaths) {
                name = new FileInfo(filePath).Name;
                name = name.ToLower();

                if (Lists.DSMIitems_files.Contains(name)) {
                    fileCounter++;
                    File.Delete(filePath);
                }
            }

            // Deleting directories -----
            string[] dirPaths = Directory.GetDirectories(DATApath);
            foreach (string dirPath in dirPaths) {
                name = new DirectoryInfo(dirPath).Name;
                name = name.ToLower();

                if (Lists.DSMIitems_directories.Contains(name)) {
                    dirCounter++;
                    Directory.Delete(dirPath, true);
                }
            }

            // Count -----
            if ((fileCounter > 0) || (dirCounter > 0)) {
                MessageBox.Show(Strings.Message_uninstalledElements(fileCounter, dirCounter, lang));
                Close();
            } else {
                MessageBox.Show(Strings.ErrorMsg_nothingToUninstall(lang));
            }

        }

        public void uninstallMostElements() {

            // Deleting files -----
            string[] filePaths = Directory.GetFiles(DATApath);
            foreach (string filePath in filePaths) {
                name = new FileInfo(filePath).Name;
                name = name.ToLower();

                if ((!(Lists.vanillaItems_files.Contains(name))) && (!(Lists.otherNonVanilla_files.Contains(name)))) {
                    fileCounter++;
                    File.Delete(filePath);
                }
            }
            
            // Deleting directories -----
            string[] dirPaths = Directory.GetDirectories(DATApath);
            foreach (string dirPath in dirPaths) {
                name = new DirectoryInfo(dirPath).Name;
                name = name.ToLower();

                if ((!(Lists.vanillaItems_directories.Contains(name))) && (!(Lists.otherNonVanilla_directories.Contains(name)))) {
                    dirCounter++;
                    Directory.Delete(dirPath, true);
                }
            }
            
            // Count -----
            if ((fileCounter > 0) || (dirCounter > 0)) {
                MessageBox.Show(Strings.Message_uninstalledElements(fileCounter, dirCounter, lang));
                Close();
            } else {
                MessageBox.Show(Strings.ErrorMsg_nothingToUninstall(lang));
            }

        }

        public void uninstallAllElements() {

            // Deleting files -----
            string[] filePaths = Directory.GetFiles(DATApath);
            foreach (string filePath in filePaths) {
                name = new FileInfo(filePath).Name;
                name = name.ToLower();

                if (!(Lists.vanillaItems_files.Contains(name))) {
                    fileCounter++;
                    File.Delete(filePath);
                }
            }

            // Deleting directories -----
            string[] dirPaths = Directory.GetDirectories(DATApath);
            foreach (string dirPath in dirPaths) {
                name = new DirectoryInfo(dirPath).Name;
                name = name.ToLower();

                if (!(Lists.vanillaItems_directories.Contains(name))) {
                    dirCounter++;
                    Directory.Delete(dirPath, true);
                }
            }

            // Count -----
            if ((fileCounter > 0) || (dirCounter > 0)) {
                MessageBox.Show(Strings.Message_uninstalledElements(fileCounter, dirCounter, lang));
                Close();
            } else {
                MessageBox.Show(Strings.ErrorMsg_nothingToUninstall(lang));
            }

        }

    }
}
