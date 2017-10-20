using Resources; // Resources.dll
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms; // Right-click on References -> Add reference ...
using System.Windows.Media;

namespace DSMI_MainLauncher {

    public partial class ProjectSettings : Window {

        public static string startDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\";
        public const string DATAdefaultLocation = @"C:\Program Files (x86)\Steam\steamapps\common\Dark Souls Prepare to Die Edition\DATA\";
        public string settingsFile = startDir + @"\DSMI_settings.txt";

        public string DATApath;
        public string lang;
        public string mode;

        BrushConverter bc = new BrushConverter();

        public void SetLanguage(string lan) {
            label_dataPathLocation.Content = Strings.label_dataPathLocation_contentLanguage(lan);
            button_browseDataPath.Content = Strings.button_browseDataPath_contentLanguage(lan);
            label_languageChoice.Content = Strings.label_languageChoice_contentLanguage(lan);
            label_compatibilityMode.Content = Strings.label_compatibilityMode_contentLanguage(lang);
            radioButton_minMode.Content = Strings.radioButton_minMode_contentLanguage(lan);
            button_Apply.Content = Strings.button_Apply_contentLanguage(lan);

            switch (lan) {
                case "fr":
                    radioButton_french.IsChecked = true;
                    break;
                case "sp":
                    radioButton_spanish.IsChecked = true;
                    break;
                default:
                    radioButton_english.IsChecked = true;
                    break;
            }
        }

        public ProjectSettings() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            // Read data from DSMI_settings.txt -----
            if (File.Exists(settingsFile)) {
                lang = Functions.GetValueFromFile(settingsFile, "language", 0);

                DATApath = Functions.ParseDataPathValue(settingsFile, "dataFolderPath");
                if (DATApath != "" && DATApath.Substring(DATApath.Length - 1) != @"\") {
                    DATApath = DATApath + @"\";
                }

                mode = Functions.GetValueFromFile(settingsFile, "modSupport", 0);
                if (mode == "normal") {
                    radioButton_normalMode.IsChecked = true;
                }
                else if (mode == "minimal") {
                    radioButton_minMode.IsChecked = true;
                }
            }
            else {
                if (mode == "" || mode == null) {
                    radioButton_normalMode.IsChecked = true;
                }
            }

            SetLanguage(lang);

            // Use other ways to find the DATA folder -----
            if (Functions.CheckPath(DATApath) == false) {
                if (Directory.Exists(DATAdefaultLocation)) {
                    DATApath = DATAdefaultLocation;
                } else {
                    DATApath = Functions.GetDataFolderPathWithRegistry();
                }
            }

            // If DATApath is OK : enable the Apply button
            // Else : use the Browse button to locate the DATA folder manually
            if (Functions.CheckPath(DATApath) == true) {
                textBox_dataPathLocation.Background = (Brush)bc.ConvertFrom("#dcffdc");
                button_Apply.IsEnabled = true;
            } else {
                textBox_dataPathLocation.Background = (Brush)bc.ConvertFrom("#ffcccc");
                System.Windows.MessageBox.Show(Strings.ErrorMsg_invalidDataPath_projectSettings(lang));
            }

            textBox_dataPathLocation.Text = DATApath;
        }


        #region radioButton events

        private void radioButton_english_Checked(object sender, RoutedEventArgs e) {
            string new_lang = "en";

            if (new_lang != lang && lang != "") {
                lang = "en";
                SetLanguage(lang);
            }
        }

        private void radioButton_french_Checked(object sender, RoutedEventArgs e) {
            string new_lang = "fr";

            if (new_lang != lang) {
                lang = "fr";
                SetLanguage(lang);
            }
        }

        private void radioButton_spanish_Checked(object sender, RoutedEventArgs e) {
            string new_lang = "sp";

            if (new_lang != lang) {
                lang = "sp";
                SetLanguage(lang);
            }
        }

        private void radioButton_normalMode_Checked(object sender, RoutedEventArgs e) {
            if (mode != "normal") { mode = "normal"; }
        }

        private void radioButton_minMode_Checked(object sender, RoutedEventArgs e) {
            if (mode != "minimal") { mode = "minimal"; }
        }

        #endregion


        private void button_browseDataPath_Click(object sender, RoutedEventArgs e) {

            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                fbd.Description = Strings.dialog_browseDatapath_descriptionLanguage(lang);
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK) {

                    textBox_dataPathLocation.Text = fbd.SelectedPath + @"\";

                    if (Functions.CheckPath(textBox_dataPathLocation.Text) == true) {
                        textBox_dataPathLocation.Background = (Brush)bc.ConvertFrom("#dcffdc");
                        button_Apply.IsEnabled = true;
                    } else {
                        textBox_dataPathLocation.Background = (Brush)bc.ConvertFrom("#ffcccc");
                        System.Windows.MessageBox.Show(Strings.ErrorMsg_invalidDataPath_projectSettings(lang));
                    }
                }
            }

        }

        private void button_Apply_Click(object sender, RoutedEventArgs e) {

            string dataFolderPath = textBox_dataPathLocation.Text;

            Outer:

            // Edit file DSMI_settings.txt -----
            if (File.Exists(startDir + @"\DSMI_settings.txt")) {
                int line_to_change;

                if (Functions.GetValueFromFile(startDir + @"\DSMI_settings.txt", "dataFolderPath", 0) != dataFolderPath) {
                    line_to_change = Functions.GetLine(startDir + @"\DSMI_settings.txt", "dataFolderPath", 0);

                    if (line_to_change > 0) {
                        Functions.LineChanger("dataFolderPath " + dataFolderPath, startDir + @"\DSMI_settings.txt", line_to_change);
                    } else {
                        File.Delete(startDir + @"\DSMI_settings.txt");
                        goto Outer; // Reach "Outer" label then the Else statement (to create the file instead editing it)
                    }
                }

                if (Functions.GetValueFromFile(startDir + @"\DSMI_settings.txt", "language", 0) != lang) {
                    line_to_change = Functions.GetLine(startDir + @"\DSMI_settings.txt", "language", 0);

                    if (line_to_change > 0) {
                        Functions.LineChanger("language " + lang, startDir + @"\DSMI_settings.txt", line_to_change);
                    } else {
                        File.Delete(startDir + @"\DSMI_settings.txt");
                        goto Outer; // Reach "Outer" label then the Else statement (to create the file instead editing it)
                    }
                }

                if (Functions.GetValueFromFile(startDir + @"\DSMI_settings.txt", "modSupport", 0) != mode) {
                    line_to_change = Functions.GetLine(startDir + @"\DSMI_settings.txt", "modSupport", 0);

                    if (line_to_change > 0) {
                        Functions.LineChanger("modSupport " + mode, startDir + @"\DSMI_settings.txt", line_to_change);
                    } else {
                        File.Delete(startDir + @"\DSMI_settings.txt");
                        goto Outer; // Reach "Outer" label then the Else statement (to create the file instead editing it)
                    }
                }

                System.Windows.MessageBox.Show(Strings.Message_settingsApplied(lang));
                Close();
            }

            // Create file DSMI_settings.txt -----
            else {
                try {
                    WriteInTxt(lang, dataFolderPath);
                    System.Windows.MessageBox.Show(Strings.Message_settingsApplied(lang));
                    Close();
                } catch (Exception ex) {
                    System.Windows.MessageBox.Show(ex.ToString());
                }
            }

        }

        public void WriteInTxt(string langValue, string dataPathValue) {

            using (StreamWriter sw = new StreamWriter(startDir + @"\DSMI_settings.txt")) {
                sw.WriteLine("# DSMI Global Settings");
                sw.WriteLine("");
                sw.WriteLine("# This file contains data used by various DSMI programs");
                sw.WriteLine("# There is a GUI program to edit the values, but you can do it manually if you prefer");
                sw.WriteLine("");
                sw.WriteLine("dataFolderPath " + dataPathValue);
                sw.WriteLine("language " + langValue);
                sw.WriteLine("modSupport " + mode);
                sw.WriteLine("");
            }

        }

    }
}
