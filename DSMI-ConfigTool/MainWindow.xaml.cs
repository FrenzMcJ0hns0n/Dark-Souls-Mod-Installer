﻿using Resources; // Resources.dll
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using WPFCustomMessageBox; // https://github.com/evanwon/WPFCustomMessageBox

namespace DSMI_ConfigTool {

    public partial class MainWindow : Window {

        public static string startDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\";
        public string sourceDir = Path.GetFullPath(Path.Combine(startDir, @"..\Source\"));
        public string NBGIfile = Path.GetFullPath(Path.Combine(Environment.GetEnvironmentVariable("appdata"), @"..\Local\NBGI\DarkSouls\DarkSouls.ini"));
        public string DATApath;
        public string lang;
        public string modSupport;

        public string SETTINGS_FILE;
        public string DS_FIX_INI_FILE;
        public string DS_FIX_TEXTURE_FOLDER;
        public string DVDBND3_FOLDER;
        public string DSPW_INI_FILE;
        public string SWEET_FX_FILE;
        public string SWEET_FX_PRESET_FOLDER;
        public string FPS_FIX_INI_FILE;

        public int line_to_change;
        public string interm_value = "";

        // Not sure to keep this :
        public bool error;
        public string where = "";

        BrushConverter bc = new BrushConverter();


        /// GUI GLOBAL VARS -----

        // Resolution
        public int renderWidth_gotValue;
        public int renderHeight_gotValue;
        public int presentWidth_gotValue;
        public int presentHeight_gotValue;

        // Depth of Field
        public int dofOverrideResolution_gotValue;
        public int dofBlurAmount_gotValue;

        // Ambient Occlusion
        public int aoStrength_gotValue;
        public string aoType_gotValue;

        // Framerate
        public int unlockFPS_gotValue;
        public int maxFPS_gotValue;
        public string framerateToggleKey_gotValue;

        // Language
        public string overrideLanguage_gotValue;

        // DInput Wrapper
        public string dinput8dllWrapper_gotValue;

        // Mouse
        public int disableCursor_gotvalue;
        public int captureCursor_gotValue;
        public bool oldMouseFix_exist = false;
        public bool newMouseFix_exist = false;

        // d3d9.dll
        public string d3d9dll_fileFound;

        // DSPW
        public string dspwOverlay_gotValue;

        // SweetFX
        public string sweetFxKey_gotValue;
        public string sweetFxPreset_gotValue;
        public string[] sweetFiles;

        // FPSFix
        public string fpsFix_gotValue;
        public string fpsFixBeep_gotValue;


        public void SetLanguage(string lan) {
            // Resolution
            groupBox_resolutionOptions.Header = Strings.groupBox_resolutionOptions_headerLanguage(lan);
            label_renderRes.Content = Strings.label_renderRes_contentLanguage(lan);
            label_renderRes.ToolTip = Strings.label_renderRes_toolTipLanguage(lan);
            label_uiRes.Content = Strings.label_uiRes_contentLanguage(lan);
            label_uiRes.ToolTip = Strings.label_uiRes_toolTipLanguage(lan);
            // Depth of field
            groupBox_dofOptions.Header = Strings.groupBox_dofOptions_headerLanguage(lan);
            label_dofOverrideRes.Content = Strings.label_dofOverrideRes_contentLanguage(lan);
            label_dofOverrideRes.ToolTip = Strings.label_dofOverrideRes_toolTipLanguage(lan);
            label_dofAdditionalBlur.Content = Strings.label_dofAdditionalBlur_contentLanguage(lan);
            label_dofAdditionalBlur.ToolTip = Strings.label_dofAdditionalBlur_toolTipLanguage(lan);
            comboBox_dofAdditionalBlur.ItemsSource = Strings.comboBox_dofAdditionalBlur_values(lan);
            // Ambient occlusion
            groupBox_aoOptions.Header = Strings.groupBox_aoOptions_headerLanguage(lan);
            label_aoStrength.Content = Strings.label_aoStrength_contentLanguage(lan);
            label_aoStrength.ToolTip = Strings.label_aoStrength_toolTipLanguage(lan);
            comboBox_aoStrength.ItemsSource = Strings.comboBox_aoStrength_values(lan);
            label_aoType.Content = Strings.label_aoType_contentLanguage(lan);
            label_aoType.ToolTip = Strings.label_aoType_toolTipLanguage(lan);
            // Framerate
            checkBox_unlockFPS.Content = Strings.checkBox_unlockFPS_contentLanguage(lan);
            checkBox_unlockFPS.ToolTip = Strings.checkBox_unlockFPS_toolTipLanguage(lan);
            label_maxFPSTarget.ToolTip = Strings.shared_maxFPSTarget_toolTipLanguage(lan);
            label_writeFPS.ToolTip = Strings.shared_maxFPSTarget_toolTipLanguage(lan);
            label_toggleFramerateKey.Content = Strings.label_toggleFramerateKey_contentLanguage(lan);
            label_toggleFramerateKey.ToolTip = Strings.label_toggleFramerateKey_toolTipLanguage(lan);
            // Mouse cursor
            groupBox_mouseCursor.Header = Strings.groupBox_mouseCursor_headerLanguage(lan);
            checkBox_showCursor.Content = Strings.checkBox_showCursor_contentLanguage(lan);
            checkBox_showCursor.ToolTip = Strings.checkBox_showCursor_toolTipLanguage(lan);
            checkBox_captureCursor.Content = Strings.checkBox_captureCursor_contentLanguage(lan);
            checkBox_captureCursor.ToolTip = Strings.checkBox_captureCursor_toolTipLanguage(lan);
            // Controls
            groupBox_controlOptions.Header = Strings.groupBox_controlOptions_headerLanguage(lan);
            radioButton_gamepad.Content = Strings.radioButton_gamepad_contentLanguage(lan);
            radioButton_gamepad.ToolTip = Strings.radioButton_gamepad_toolTipLanguage(lan);
            label_gamepadButtonsStyle.Content = Strings.label_gamepadButtonsStyle_contentLanguage(lan);
            label_gamepadButtonsStyle.ToolTip = Strings.label_gamepadButtonsStyle_toolTipLanguage(lan);
            radioButton_mouse.Content = Strings.radioButton_mouse_contentLanguage(lan);
            radioButton_mouse.ToolTip = Strings.radioButton_mouse_toolTipLanguage(lan);
            radioButton_oldMouseFix.Content = Strings.radioButton_oldMouseFix_contentLanguage(lan);
            radioButton_oldMouseFix.ToolTip = Strings.radioButton_oldMouseFix_toolTipLanguage(lan);
            radioButton_newMouseFix.Content = Strings.radioButton_newMouseFix_contentLanguage(lan);
            radioButton_newMouseFix.ToolTip = Strings.radioButton_newMouseFix_toolTipLanguage(lan);
            button_configureMouse.Content = Strings.button_configureMouse_contentLanguage(lan);
            // Language
            groupBox_language.Header = Strings.groupBox_language_headerLanguage(lan);
            label_forceLanguage.Content = Strings.label_forceLanguage_contentLanguage(lan);
            label_forceLanguage.ToolTip = Strings.label_forceLanguage_toolTipLanguage(lan);
            comboBox_forceLanguage.ItemsSource = Strings.comboBox_forceLanguage_values(lan);
            // Mod settings
            checkBox_overlayDspw.Content = Strings.checkBox_overlayDspw_contentLanguage(lan);
            checkBox_overlayDspw.ToolTip = Strings.checkBox_overlayDspw_toolTipLanguage(lan);
            checkBox_sweetFX.Content = Strings.checkBox_sweetFX_contentLanguage(lan);
            checkBox_sweetFX.ToolTip = Strings.checkBox_sweetFX_toolTipLanguage(lan);
            label_sweetFxKey.Content = Strings.label_sweetFxKey_contentLanguage(lan);
            label_sweetFxKey.ToolTip = Strings.label_sweetFxKey_toolTipLanguage(lan);
            label_sweetFxPreset.ToolTip = Strings.label_sweetFxPreset_toolTipLanguage(lan);
            checkBox_FPSFix.Content = Strings.checkBox_FPSFix_contentLanguage(lan);
            checkBox_FPSFix.ToolTip = Strings.checkBox_FPSFix_toolTipLanguage(lan);
            checkBox_FPSFix_beep.Content = Strings.checkbox_FPSFixBeep_contentLanguage(lan);
            checkBox_FPSFix_beep.ToolTip = Strings.checkbox_FPSFixBeep_toolTipLanguage(lan);
            groupBox_dvdbnd3.Header = Strings.groupBox_dvdbnd3_headerLanguage(lan);
            checkBox_dvdbnd3Files.Content = Strings.checkBox_dvdbnd3Files_contentLanguage(lan);
            checkBox_dvdbnd3Files.ToolTip = Strings.checkBox_dvdbnd3Files_toolTipLanguage(lan);
            // Lower buttons
            button_saveAndExit.Content = Strings.button_saveAndExit_contentLanguage(lan);

            switch (lan) {
                case "fr":
                    checkBox_unlockFPS.Margin = new Thickness(460, 158, 0, 0);
                    checkBox_captureCursor.Margin = new Thickness(552, 270, 0, 0);
                    label_gamepadButtonsStyle.Margin = new Thickness(424, 379, 0, 0);
                    radioButton_oldMouseFix.Margin = new Thickness(562, 390, 0, 0);
                    radioButton_newMouseFix.Margin = new Thickness(562, 410, 0, 0);
                    checkBox_dvdbnd3Files.Margin = new Thickness(438, 503, 0, 0);
                    comboBox_uiRes.Items.Add("= Rendu");
                    comboBox_toggleFramerateKey.Items.Add("Retour Arrière");
                    comboBox_gamepadButtonsStyle.Items.Add("Défaut");
                    comboBox_sweetFxKey.Items.Add("Arrêt défil");
                    break;
                case "sp":
                    label_renderRes.Margin = new Thickness(65, 50, 0, 0);
                    label_dofAdditionalBlur.Margin = new Thickness(564, 50, 0, 0);
                    label_aoStrength.Margin = new Thickness(58, 159, 0, 0);
                    checkBox_unlockFPS.Margin = new Thickness(456, 158, 0, 0);
                    label_forceLanguage.Margin = new Thickness(81, 260, 0, 0);
                    label_gamepadButtonsStyle.Margin = new Thickness(424, 379, 0, 0);
                    checkBox_dvdbnd3Files.Margin = new Thickness(433, 503, 0, 0);
                    comboBox_uiRes.Items.Add("= Principal");
                    comboBox_toggleFramerateKey.Items.Add("Backspace");
                    comboBox_gamepadButtonsStyle.Items.Add("Por defecto");
                    comboBox_sweetFxKey.Items.Add("Scroll lock");
                    break;
                default:
                    label_renderRes.Margin = new Thickness(60, 50, 0, 0);
                    label_forceLanguage.Margin = new Thickness(74, 260, 0, 0);
                    comboBox_uiRes.Items.Add("= Rendering");
                    comboBox_toggleFramerateKey.Items.Add("Backspace");
                    comboBox_gamepadButtonsStyle.Items.Add("Default");
                    comboBox_sweetFxKey.Items.Add("Scroll lock");
                    break;
            }

            foreach (string item in Lists.uiRes_Values) {
                comboBox_uiRes.Items.Add(item);
            }

            comboBox_toggleFramerateKey.Items.Add("F2");
            comboBox_sweetFxKey.Items.Add("F3");

            foreach (string item in Lists.gamepadButtonsStyle_Values) {
                comboBox_gamepadButtonsStyle.Items.Add(item);
            }
        }
        
        public MainWindow() {

            if (!(File.Exists(startDir + "Resources.dll"))) {
                MessageBox.Show("Error : File \"Resources.dll\" not found !\n\nPlease check your setup then try again.");
                Environment.Exit(0);
            }

            InitializeComponent();

            if (File.Exists(startDir + @"\DSMI_settings.txt")) {

                DATApath = Functions.GetValueFromFile(startDir + @"\DSMI_settings.txt", "dataFolderPath", 0);

                if (DATApath != "") {
                    if (DATApath.Substring(DATApath.Length - 1) != @"\") {
                        DATApath = DATApath + @"\";
                    }
                }
                if (!(File.Exists(DATApath + "fmodex.dll")) || !(File.Exists(DATApath + "fmod_event.dll"))) {
                    MessageBox.Show(Strings.ErrorMsg_invalidDataPath(lang));
                    Environment.Exit(0);
                }

                lang = Functions.GetValueFromFile(startDir + @"\DSMI_settings.txt", "language", 0);
                SetLanguage(lang); // default is English : doesn't matter if "lang" is null

                modSupport = Functions.GetValueFromFile(startDir + @"\DSMI_settings.txt", "modSupport", 0);
            }
            else {
                MessageBox.Show(Strings.ErrorMsg_projectSettingsFileNotFound(lang));
                Environment.Exit(0);
            }
            
            // Define files & folders aliases -----
            DS_FIX_INI_FILE = DATApath + "DSfix.ini";
            DS_FIX_TEXTURE_FOLDER = DATApath + @"dsfix\tex_override\";
            DVDBND3_FOLDER = DATApath + @"dvdbnd3\";
            DSPW_INI_FILE = DATApath + "DSPWSteam.ini";
            SWEET_FX_FILE = DATApath + "SweetFX_settings.txt";
            SWEET_FX_PRESET_FOLDER = DATApath + @"SweetFX\Presets\";
            FPS_FIX_INI_FILE = DATApath + "FPSFix.ini";


            // File checkup -----
            if (!(File.Exists(NBGIfile))) {
                MessageBox.Show(Strings.ErrorMsg_NBGIfileNotFound(NBGIfile, lang));
                Environment.Exit(0);
            }

            if (!(File.Exists(DS_FIX_INI_FILE)) || !(File.Exists(DATApath + "DINPUT8.dll")) || !(File.Exists(DATApath + "DSfixKeys.ini"))) {
                MessageBox.Show(Strings.ErrorMsg_missingFiles("DSfix", lang));
                Environment.Exit(0);
            }

            /* TODO (v4) : Disable mods in minimal mode, but display them.
             * As it is now, the user does not see the mods in the GUI but they are still active ...
             * Also : Add a button to switch between normal and minimal modes in the GUI ?
             */
            if (modSupport == "normal") {
                if (!(File.Exists(DSPW_INI_FILE)) || !(File.Exists(DATApath + "msvcp120.dll")) || !(File.Exists(DATApath + "msvcr120.dll"))) {
                    MessageBox.Show(Strings.ErrorMsg_missingFiles("Dark Souls PvP Watchdog", lang));
                    Environment.Exit(0);
                }
                if (!(File.Exists(startDir + @"\WPFCustomMessageBox.dll"))) {
                    MessageBox.Show(Strings.ErrorMsg_missingDll("WPFCustomMessageBox.dll", lang));
                    Environment.Exit(0);
                }
            }
            else {
                // Hide mods -----
                groupBox_pvpWatchdog.Visibility = Visibility.Hidden;
                checkBox_overlayDspw.Visibility = Visibility.Hidden;

                groupBox_FPSFix.Visibility = Visibility.Hidden;
                checkBox_FPSFix.Visibility = Visibility.Hidden;
                checkBox_FPSFix_beep.Visibility = Visibility.Hidden;

                groupBox_sweetFX.Visibility = Visibility.Hidden;
                checkBox_sweetFX.Visibility = Visibility.Hidden;
                label_sweetFxKey.Visibility = Visibility.Hidden;
                comboBox_sweetFxKey.Visibility = Visibility.Hidden;
                label_sweetFxPreset.Visibility = Visibility.Hidden;
                comboBox_sweetFxPreset.Visibility = Visibility.Hidden;

                groupBox_dvdbnd3.Visibility = Visibility.Hidden;
                checkBox_dvdbnd3Files.Visibility = Visibility.Hidden;
                comboBox_dvdbnd3Files.Visibility = Visibility.Hidden;

                groupBox_shortcuts.Visibility = Visibility.Hidden;
                button_openTexFolder.Visibility = Visibility.Hidden;
                button_openSFPresets.Visibility = Visibility.Hidden;
                button_openDvdbnd3Folder.Visibility = Visibility.Hidden;

                // Adapt window for minimal mode -----
                Title = "DSMI Config Tool (minimal mode)";
                Height = 568;
                groupBox_controlOptions.HorizontalAlignment = HorizontalAlignment.Center;
                groupBox_controlOptions.Margin = new Thickness(0, 316, 0, 0);
                button_configureMouse.HorizontalAlignment = HorizontalAlignment.Left;
                button_configureMouse.Width = 140;
                button_configureMouse.Margin = new Thickness(361, 432, 0, 0);
                button_saveAndExit.HorizontalAlignment = HorizontalAlignment.Center;
                button_saveAndExit.Margin = new Thickness(0, 0, 0, 21);

                switch (lang) {
                    case "fr":
                        radioButton_gamepad.Margin = new Thickness(236, 345, 0, 0);
                        label_gamepadButtonsStyle.Margin = new Thickness(252, 377, 0, 0);
                        comboBox_gamepadButtonsStyle.Margin = new Thickness(223, 403, 0, 0);
                        radioButton_mouse.Margin = new Thickness(398, 345, 0, 0);
                        radioButton_oldMouseFix.Margin = new Thickness(388, 384, 0, 0);
                        radioButton_newMouseFix.Margin = new Thickness(388, 402, 0, 0);
                        break;
                    case "sp":
                        radioButton_gamepad.Margin = new Thickness(240, 345, 0, 0);
                        label_gamepadButtonsStyle.Margin = new Thickness(250, 377, 0, 0);
                        comboBox_gamepadButtonsStyle.Margin = new Thickness(223, 403, 0, 0);
                        radioButton_mouse.Margin = new Thickness(404, 345, 0, 0);
                        radioButton_oldMouseFix.Margin = new Thickness(394, 384, 0, 0);
                        radioButton_newMouseFix.Margin = new Thickness(394, 402, 0, 0);
                        break;
                    default:
                        radioButton_gamepad.Margin = new Thickness(236, 345, 0, 0);
                        label_gamepadButtonsStyle.Margin = new Thickness(252, 377, 0, 0);
                        comboBox_gamepadButtonsStyle.Margin = new Thickness(223, 403, 0, 0);
                        radioButton_mouse.Margin = new Thickness(398, 345, 0, 0);
                        radioButton_oldMouseFix.Margin = new Thickness(396, 384, 0, 0);
                        radioButton_newMouseFix.Margin = new Thickness(396, 402, 0, 0);
                        break;
                }
            }

            // Fill non language-relative comboBoxes -----
            comboBox_renderRes.ItemsSource = Lists.renderRes_Values;
            comboBox_dofOverrideRes.ItemsSource = Lists.dofOverrideRes_Values;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            LoadData();

            if (error == true) {
                MessageBox.Show(Strings.Warning_wrongLoadedData(lang) + where);
            }
        }


        #region GUI events

        private void comboBox_aoStrength_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {

            if (comboBox_aoStrength.SelectedIndex == 0) {
                label_aoType.IsEnabled = false;
                comboBox_aoType.IsEnabled = false;
                comboBox_aoType.Foreground = (Brush)bc.ConvertFrom("#888");
            } else {
                label_aoType.IsEnabled = true;
                comboBox_aoType.IsEnabled = true;
                comboBox_aoType.Foreground = (Brush)bc.ConvertFrom("#000");
            }
        }

        private void checkBox_unlockFPS_Checked(object sender, RoutedEventArgs e) {

            label_maxFPSTarget.IsEnabled = true;
            comboBox_maxFPSTarget.SelectedIndex = 1;
            comboBox_maxFPSTarget.IsEnabled = true;
            comboBox_maxFPSTarget.Foreground = (Brush)bc.ConvertFrom("#000");
            label_writeFPS.IsEnabled = true;

            label_toggleFramerateKey.IsEnabled = true;
            comboBox_toggleFramerateKey.IsEnabled = true;
            comboBox_toggleFramerateKey.Foreground = (Brush)bc.ConvertFrom("#000");
        }

        private void checkBox_unlockFPS_Unchecked(object sender, RoutedEventArgs e) {

            label_maxFPSTarget.IsEnabled = false;
            comboBox_maxFPSTarget.SelectedIndex = 0;
            comboBox_maxFPSTarget.IsEnabled = false;
            comboBox_maxFPSTarget.Foreground = (Brush)bc.ConvertFrom("#888");
            label_writeFPS.IsEnabled = false;

            label_toggleFramerateKey.IsEnabled = false;
            comboBox_toggleFramerateKey.IsEnabled = false;
            comboBox_toggleFramerateKey.Foreground = (Brush)bc.ConvertFrom("#888");
        }

        private void checkBox_sweetFX_Checked(object sender, RoutedEventArgs e) {

            label_sweetFxKey.IsEnabled = true;
            comboBox_sweetFxKey.IsEnabled = true;
            label_sweetFxKey.Foreground = (Brush)bc.ConvertFrom("#000");
            comboBox_sweetFxKey.Foreground = (Brush)bc.ConvertFrom("#000");

            label_sweetFxPreset.IsEnabled = true;
            comboBox_sweetFxPreset.IsEnabled = true;
            label_sweetFxPreset.Foreground = (Brush)bc.ConvertFrom("#000");
            comboBox_sweetFxPreset.Foreground = (Brush)bc.ConvertFrom("#000");
        }

        private void checkBox_sweetFX_Unchecked(object sender, RoutedEventArgs e) {

            label_sweetFxKey.IsEnabled = false;
            comboBox_sweetFxKey.IsEnabled = false;
            label_sweetFxKey.Foreground = (Brush)bc.ConvertFrom("#888");
            comboBox_sweetFxKey.Foreground = (Brush)bc.ConvertFrom("#888");

            label_sweetFxPreset.IsEnabled = false;
            comboBox_sweetFxPreset.IsEnabled = false;
            label_sweetFxPreset.Foreground = (Brush)bc.ConvertFrom("#888");
            comboBox_sweetFxPreset.Foreground = (Brush)bc.ConvertFrom("#888");
        }

        private void checkBox_FPSFix_Checked(object sender, RoutedEventArgs e) {
            checkBox_FPSFix_beep.IsEnabled = true;
            checkBox_FPSFix_beep.Foreground = (Brush)bc.ConvertFrom("#000");
        }

        private void checkBox_FPSFix_Unchecked(object sender, RoutedEventArgs e) {
            checkBox_FPSFix_beep.IsEnabled = false;
            checkBox_FPSFix_beep.Foreground = (Brush)bc.ConvertFrom("#888");
            checkBox_FPSFix_beep.IsChecked = false;
        }

        private void radioButton_gamepad_Checked(object sender, RoutedEventArgs e) {
            button_configureMouse.IsEnabled = false;
            button_configureMouse.Foreground = (Brush)bc.ConvertFrom("#888");

            radioButton_oldMouseFix.IsChecked = false;
            radioButton_oldMouseFix.IsEnabled = false;
            radioButton_oldMouseFix.Foreground = (Brush)bc.ConvertFrom("#888");
            radioButton_newMouseFix.IsChecked = false;
            radioButton_newMouseFix.IsEnabled = false;
            radioButton_newMouseFix.Foreground = (Brush)bc.ConvertFrom("#888");

            label_gamepadButtonsStyle.IsEnabled = true;
            comboBox_gamepadButtonsStyle.IsEnabled = true;
            comboBox_gamepadButtonsStyle.Foreground = (Brush)bc.ConvertFrom("#000");
        }

        private void radioButton_mouse_Checked(object sender, RoutedEventArgs e) {
            button_configureMouse.IsEnabled = true;
            button_configureMouse.Foreground = (Brush)bc.ConvertFrom("#000");

            checkBox_showCursor.IsChecked = true;
            checkBox_captureCursor.IsChecked = true;

            label_gamepadButtonsStyle.IsEnabled = false;
            comboBox_gamepadButtonsStyle.IsEnabled = false;
            comboBox_gamepadButtonsStyle.Foreground = (Brush)bc.ConvertFrom("#888");

            if (oldMouseFix_exist) {
                radioButton_oldMouseFix.IsEnabled = true;
                radioButton_oldMouseFix.Foreground = (Brush)bc.ConvertFrom("#000");
            }
            if (newMouseFix_exist) {
                radioButton_newMouseFix.IsEnabled = true;
                radioButton_newMouseFix.Foreground = (Brush)bc.ConvertFrom("#000");
            }
        }

        private void checkBox_dvdbnd3Files_Checked(object sender, RoutedEventArgs e) {
            comboBox_dvdbnd3Files.SelectedIndex = 0;
            comboBox_dvdbnd3Files.IsEnabled = true;
            comboBox_dvdbnd3Files.Foreground = (Brush)bc.ConvertFrom("#000");
        }

        private void checkBox_dvdbnd3Files_Unchecked(object sender, RoutedEventArgs e) {
            comboBox_dvdbnd3Files.SelectedItem = null;
            comboBox_dvdbnd3Files.IsEnabled = false;
            comboBox_dvdbnd3Files.Foreground = (Brush)bc.ConvertFrom("#888");
        }

        private void button_openTexFolder_Click(object sender, RoutedEventArgs e) {
            try {
                Process.Start(DS_FIX_TEXTURE_FOLDER);
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_openSFPresets_Click(object sender, RoutedEventArgs e) {
            try {
                Process.Start(SWEET_FX_PRESET_FOLDER);
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_openDvdbnd3Folder_Click(object sender, RoutedEventArgs e) {
            try {
                Process.Start(DVDBND3_FOLDER);
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion


        private void button_configureMouse_Click(object sender, RoutedEventArgs e) {

            if (radioButton_oldMouseFix.IsChecked == true) {
                Directory.SetCurrentDirectory(DATApath);
                try {
                    System.Diagnostics.Process.Start("dsmfixgui.exe");
                } catch {
                    MessageBox.Show(Strings.ErrorMsg_dsmfixGuiNotFound("dsmfixgui.exe", lang));
                } finally {
                    Directory.SetCurrentDirectory(startDir);
                }
            }
            else if (radioButton_newMouseFix.IsChecked == true) {
                Directory.SetCurrentDirectory(DATApath);
                try {
                    System.Diagnostics.Process.Start("DarkSoulsMouseFixGUI.exe");
                } catch {
                    MessageBox.Show(Strings.ErrorMsg_dsmfixGuiNotFound("DarkSoulsMouseFixGUI.exe", lang));
                } finally {
                    Directory.SetCurrentDirectory(startDir);
                }
            }
            else {
                MessageBox.Show(Strings.ErrorMsg_noMouseFixChosen(lang));
            }
        }

        private void button_SaveAndExit_Click(object sender, RoutedEventArgs e) {

            // Does the job, but could be better
            bool resol_ok = true;
            bool mouse_ok = true;

            if (comboBox_renderRes.SelectedIndex > 4 && comboBox_uiRes.SelectedIndex == 0) {
                resol_ok = false;
            }

            if (radioButton_mouse.IsChecked == true && 
                radioButton_oldMouseFix.IsChecked == false && 
                radioButton_newMouseFix.IsChecked == false) {
                mouse_ok = false;
            } else {
                border_mouse.BorderBrush = (Brush)bc.ConvertFromString("Transparent");
            }

            if (resol_ok && mouse_ok) {
                EditFiles();
                MessageBox.Show(Strings.Message_appliedSettings(lang));
                Environment.Exit(0);
            }
            else {
                if (resol_ok == false) {
                    MessageBox.Show(Strings.ErrorMsg_wrongResolutionChoice(lang));
                }
                if (mouse_ok == false) {
                    MessageBox.Show(Strings.ErrorMsg_noMouseFixChosen(lang));
                }
            }

        }

        public void LoadData() {

            // GET : Rendering resolution -----
            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "renderWidth", 0);
            if (int.TryParse(interm_value, out renderWidth_gotValue) == true) {
                renderWidth_gotValue = int.Parse(interm_value);
            }
            else {
                renderWidth_gotValue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "\"renderWidth\" (DSfix.ini)\n";
                }
            }

            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "renderHeight", 0);
            if (int.TryParse(interm_value, out renderHeight_gotValue)) {

                switch (renderHeight_gotValue) {
                    case 2160:
                        if (renderWidth_gotValue == 3840) {
                            comboBox_renderRes.SelectedIndex = 0;
                        }
                        break;

                    case 1440:
                        if (renderWidth_gotValue == 2560) {
                            comboBox_renderRes.SelectedIndex = 1;
                        }
                        break;

                    case 1080:
                        if (renderWidth_gotValue == 1920) {
                            comboBox_renderRes.SelectedIndex = 2;
                        }
                        break;

                    case 900:
                        if (renderWidth_gotValue == 1600) {
                            comboBox_renderRes.SelectedIndex = 3;
                        }
                        break;

                    case 720:
                        if (renderWidth_gotValue == 1280) {
                            comboBox_renderRes.SelectedIndex = 4;
                        }
                        break;

                    case 576:
                        if (renderWidth_gotValue == 1024) {
                            comboBox_renderRes.SelectedIndex = 5;
                        }
                        break;

                    case 504:
                        if (renderWidth_gotValue == 896) {
                            comboBox_renderRes.SelectedIndex = 6;
                        }
                        break;

                    case 432:
                        if (renderWidth_gotValue == 768) {
                            comboBox_renderRes.SelectedIndex = 7;
                        }
                        break;

                    case 360:
                        if (renderWidth_gotValue == 640) {
                            comboBox_renderRes.SelectedIndex = 8;
                        }
                        break;

                    case 288:
                        if (renderWidth_gotValue == 512) {
                            comboBox_renderRes.SelectedIndex = 9;
                        }
                        break;

                    case 216:
                        if (renderWidth_gotValue == 384) {
                            comboBox_renderRes.SelectedIndex = 10;
                        }
                        break;
                }
            }
            else {
                renderHeight_gotValue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "\"renderHeight\" (DSfix.ini)\n";
                }
            }
            
            // GET : Interface resolution -----
            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "presentWidth", 0);
            if (int.TryParse(interm_value, out presentWidth_gotValue) == true) {
                presentWidth_gotValue = int.Parse(interm_value);
            }
            else {
                presentWidth_gotValue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "\"presentWidth\" (DSfix.ini)\n";
                }
            }

            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "presentHeight", 0);
            if (int.TryParse(interm_value, out presentHeight_gotValue)) {

                switch (presentHeight_gotValue) {
                    case 0:
                        if (presentWidth_gotValue == 0) {
                            comboBox_uiRes.SelectedIndex = 0;
                        }
                        break;

                    case 2160:
                        if (presentWidth_gotValue == 3840) {
                            comboBox_uiRes.SelectedIndex = 1;
                        }
                        break;

                    case 1440:
                        if (presentWidth_gotValue == 2560) {
                            comboBox_uiRes.SelectedIndex = 2;
                        }
                        break;

                    case 1080:
                        if (presentWidth_gotValue == 1920) {
                            comboBox_uiRes.SelectedIndex = 3;
                        }
                        break;

                    case 900:
                        if (presentWidth_gotValue == 1600) {
                            comboBox_uiRes.SelectedIndex = 4;
                        }
                        break;

                    case 720:
                        if (presentWidth_gotValue == 1280) {
                            comboBox_uiRes.SelectedIndex = 5;
                        }
                        break;
                }
            }
            else {
                presentHeight_gotValue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "\"presentHeight\" (DSfix.ini)\n";
                }
            }
            
            // GET : Depth of Field resolution override -----
            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "dofOverrideResolution", 0);
            if (int.TryParse(interm_value, out dofOverrideResolution_gotValue)) {

                switch (dofOverrideResolution_gotValue) {
                    case 360:
                        comboBox_dofOverrideRes.SelectedIndex = 0;
                        break;

                    case 540:
                        comboBox_dofOverrideRes.SelectedIndex = 1;
                        break;

                    case 810:
                        comboBox_dofOverrideRes.SelectedIndex = 2;
                        break;

                    case 1080:
                        comboBox_dofOverrideRes.SelectedIndex = 3;
                        break;

                    case 2160:
                        comboBox_dofOverrideRes.SelectedIndex = 4;
                        break;
                }
            }
            else {
                dofOverrideResolution_gotValue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "\"dofOverrideResolution\" (DSfix.ini)\n";
                }
            }
            
            // GET : Depth of Field additional blur -----
            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "dofBlurAmount", 0);
            if (int.TryParse(interm_value, out dofBlurAmount_gotValue)) {

                switch (dofBlurAmount_gotValue) {
                    case 0:
                        comboBox_dofAdditionalBlur.SelectedIndex = 0;
                        break;

                    case 1:
                        comboBox_dofAdditionalBlur.SelectedIndex = 1;
                        break;

                    case 2:
                        comboBox_dofAdditionalBlur.SelectedIndex = 2;
                        break;

                    case 3:
                        comboBox_dofAdditionalBlur.SelectedIndex = 3;
                        break;

                    case 4:
                        comboBox_dofAdditionalBlur.SelectedIndex = 4;
                        break;
                }
            }
            else {
                dofBlurAmount_gotValue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "\"dofBlurAmount\" (DSfix.ini)\n";
                }
            }

            // GET : Ambient Occlusion strength -----
            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "ssaoStrength", 0);
            if (int.TryParse(interm_value, out aoStrength_gotValue)) {

                switch (aoStrength_gotValue) {
                    case 0:
                        comboBox_aoStrength.SelectedIndex = 0;
                        break;

                    case 1:
                        comboBox_aoStrength.SelectedIndex = 1;
                        break;

                    case 2:
                        comboBox_aoStrength.SelectedIndex = 2;
                        break;

                    case 3:
                        comboBox_aoStrength.SelectedIndex = 3;
                        break;
                }
            }
            else {
                aoStrength_gotValue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "\"ssaoStrength\" (DSfix.ini)\n";
                }
            }

            // GET : Ambient Occlusion type -----
            aoType_gotValue = Functions.GetValueFromFile(DS_FIX_INI_FILE, "ssaoType", 0);
            switch (aoType_gotValue) {
                case "VSSAO":
                    comboBox_aoType.SelectedIndex = 0;
                    break;

                case "HBAO":
                    comboBox_aoType.SelectedIndex = 1;
                    break;

                case "SCAO":
                    comboBox_aoType.SelectedIndex = 2;
                    break;

                case "VSSAO2":
                    comboBox_aoType.SelectedIndex = 3;
                    break;

                case "noMatch":
                    error = true;
                    where = where + "\"ssaoType\" (DSfix.ini)\n";
                    break;
            }

            // GET : Unlock framerate -----
            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "unlockFPS", 0);
            if (int.TryParse(interm_value, out unlockFPS_gotValue)) {

                switch (unlockFPS_gotValue) {
                    case 0:
                        checkBox_unlockFPS.IsChecked = false;
                        break;

                    case 1:
                        checkBox_unlockFPS.IsChecked = true;
                        break;
                }
            }
            else {
                unlockFPS_gotValue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "dofOverrideResolution (DSfix.ini)\n";
                }
            }

            // GET : Max framerate -----
            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "FPSlimit", 0);
            if (int.TryParse(interm_value, out maxFPS_gotValue)) {

                switch (maxFPS_gotValue) {
                    case 30:
                        comboBox_maxFPSTarget.SelectedIndex = 0;
                        checkBox_unlockFPS.IsChecked = true;
                        checkBox_unlockFPS.IsChecked = false;
                        break;

                    case 60:
                        comboBox_maxFPSTarget.SelectedIndex = 1;
                        break;
                }
            }
            else {
                maxFPS_gotValue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "\"FPSlimit\" (DSfix.ini)\n";
                }
            }

            // GET : Framerate toggle key -----
            framerateToggleKey_gotValue = Functions.GetValueFromFile(DATApath + "DSfixKeys.ini", "toggle30FPSLimit", 0);
            switch (framerateToggleKey_gotValue) {
                case "VK_BACK":
                    comboBox_toggleFramerateKey.SelectedIndex = 0;
                    break;

                case "VK_F2":
                    comboBox_toggleFramerateKey.SelectedIndex = 1;
                    break;

                case "noMatch":
                    error = true;
                    where = where + "\"toggle30FPSLimit\" (DSfixKeys.ini)\n";
                    break;
            }
            
            // GET : Force language -----
            overrideLanguage_gotValue = Functions.GetValueFromFile(DS_FIX_INI_FILE, "overrideLanguage", 0);
            switch (overrideLanguage_gotValue) {
                case "none":
                    comboBox_forceLanguage.SelectedIndex = 0;
                    break;

                case "en-GB":
                    comboBox_forceLanguage.SelectedIndex = 1;
                    break;

                case "fr":
                    comboBox_forceLanguage.SelectedIndex = 2;
                    break;

                case "it":
                    comboBox_forceLanguage.SelectedIndex = 3;
                    break;

                case "de":
                    comboBox_forceLanguage.SelectedIndex = 4;
                    break;

                case "es":
                    comboBox_forceLanguage.SelectedIndex = 5;
                    break;

                case "ko":
                    comboBox_forceLanguage.SelectedIndex = 6;
                    break;

                case "zh-tw":
                    comboBox_forceLanguage.SelectedIndex = 7;
                    break;

                case "pl":
                    comboBox_forceLanguage.SelectedIndex = 8;
                    break;

                case "ru":
                    comboBox_forceLanguage.SelectedIndex = 9;
                    break;

                case "noMatch":
                    error = true;
                    where = where + "\"overrideLanguage\" (DSfix.ini)\n";
                    break;
            }
            
            // CHECK : Do mouse files even exist ?
            if (File.Exists(DATApath + "dsmfix.dll") && File.Exists(DATApath + "dsmfix.ini")) {
                oldMouseFix_exist = true;
            }
            if (File.Exists(DATApath + "DarkSoulsMouseFix.dll") && File.Exists(DATApath + "DarkSoulsMouseFix.ini")) {
                newMouseFix_exist = true;
            }
            if (oldMouseFix_exist || newMouseFix_exist) {
                radioButton_mouse.IsEnabled = true;
            }
            
            // GET : DirectInput wrapper -----
            dinput8dllWrapper_gotValue = Functions.GetValueFromFile(DS_FIX_INI_FILE, "dinput8dllWrapper", 0);
            switch (dinput8dllWrapper_gotValue) {
                case "none":
                    radioButton_gamepad.IsChecked = true;
                    break;

                case "dsmfix.dll":
                    if (oldMouseFix_exist) {
                        radioButton_mouse.IsChecked = true;
                        radioButton_oldMouseFix.IsChecked = true;
                    }
                    break;

                case "DarkSoulsMouseFix.dll":
                    if (newMouseFix_exist) {
                        radioButton_mouse.IsChecked = true;
                        radioButton_newMouseFix.IsChecked = true;
                    }
                    break;

                case "noMatch":
                    error = true;
                    where = where + "\"dinput8dllWrapper\" (DSfix.ini)\n";
                    break;
            }
            
            // GET : Disable mouse cursor -----
            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "disableCursor", 0);
            if (int.TryParse(interm_value, out disableCursor_gotvalue)) {

                switch (disableCursor_gotvalue) {
                    case 0:
                        checkBox_showCursor.IsChecked = true;
                        break;

                    case 1:
                        checkBox_showCursor.IsChecked = false;
                        break;
                }
            }
            else {
                disableCursor_gotvalue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "\"disableCursor\" (DSfix.ini)\n";
                }
            }
            
            // GET : Capture mouse cursor -----
            interm_value = Functions.GetValueFromFile(DS_FIX_INI_FILE, "captureCursor", 0);
            if (int.TryParse(interm_value, out captureCursor_gotValue)) {

                switch (captureCursor_gotValue) {
                    case 0:
                        checkBox_captureCursor.IsChecked = false;
                        break;

                    case 1:
                        checkBox_captureCursor.IsChecked = true;
                        break;
                }
            }
            else {
                captureCursor_gotValue = -1;
                if (interm_value == "noMatch") {
                    error = true;
                    where = where + "\"captureCursor\" (DSfix.ini)\n";
                }
            }

            // GET : Gamepad buttons -----
            bool foundTexSupported = true;

            switch (Functions.CheckFile(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png", "mainButtonsTexture")) {
                case "noFileFound":
                    comboBox_gamepadButtonsStyle.SelectedIndex = 0;
                    break;

                case "x360":
                    comboBox_gamepadButtonsStyle.SelectedIndex = 1;
                    break;

                case "xbo":
                    comboBox_gamepadButtonsStyle.SelectedIndex = 2;
                    break;

                case "ps3":
                    comboBox_gamepadButtonsStyle.SelectedIndex = 3;
                    break;

                case "ps4":
                    comboBox_gamepadButtonsStyle.SelectedIndex = 4;
                    break;

                case "unsupported":
                    foundTexSupported = false;
                    break;
            }

            if (Functions.CheckFile(DS_FIX_TEXTURE_FOLDER + "43a2b23a.png", "otherButtonsTexture") == "unsupported") {
                foundTexSupported = false;
            }

            // Textures unsupported by DSMI ? -----
            if (foundTexSupported == false) {

                switch (lang) {
                    case "fr":
                        comboBox_gamepadButtonsStyle.Items.Add("Personnalisé");
                        break;
                    case "sp":
                        comboBox_gamepadButtonsStyle.Items.Add("Personalizado");
                        break;
                    default:
                        comboBox_gamepadButtonsStyle.Items.Add("Custom");
                        break;
                }

                comboBox_gamepadButtonsStyle.SelectedIndex = 5;

                // Display warning ? -----
                if (Functions.GetValueFromFile(startDir + @"\DSMI_settings.txt", "unsupportedTextureWarning", 0) != "no") {

                    var customMsgBox = CustomMessageBox.ShowOKCancel(
                        Strings.Warning_unsupportedButtonTextures(DS_FIX_TEXTURE_FOLDER, lang),
                        "",
                        "OK",
                        Strings.CustomButtonText_DontWarnAnymore(lang)
                    );

                    if (customMsgBox == MessageBoxResult.Cancel) {
                        using (StreamWriter sw = new StreamWriter(startDir + @"\DSMI_settings.txt", true)) {
                            sw.WriteLine("unsupportedTextureWarning no");
                        }
                    }
                }

            }

            //////////   MOD SUPPORT   ////////////////////////////////////////////////

            if (modSupport == "normal") {

                // GET : FPSFix+ dll found ? -----
                if (File.Exists(DATApath + "winmm.dll")) {
                    checkBox_FPSFix.IsChecked = true;

                    fpsFixBeep_gotValue = Functions.GetValueFromFile(FPS_FIX_INI_FILE, "BeepOnDetection=", 0);

                    if (fpsFixBeep_gotValue == "1") {
                        checkBox_FPSFix_beep.IsChecked = true;
                    }
                }
                
                // GET : DSPW overlay -----
                dspwOverlay_gotValue = Functions.GetValueFromFile(DSPW_INI_FILE, "ShowVersionBanner", 0);

                switch (dspwOverlay_gotValue) {
                    case "true":
                        checkBox_overlayDspw.IsChecked = true;
                        break;

                    case "false":
                        checkBox_overlayDspw.IsChecked = false;
                        break;

                    case "noMatch":
                        error = true;
                        where = where + "\"ShowVersionBanner\" (DSPWSteam.ini)\n";
                        break;
                }
                
                // GET : d3d9.dll -----
                if (modSupport == "normal") {
                    checkBox_sweetFX.IsChecked = true;
                    checkBox_sweetFX.IsChecked = false; // wonky way to make sure the relative elements are really disabled

                    d3d9dll_fileFound = Functions.CheckFile(DATApath + "d3d9.dll", "d3d9_dll"); // Here we know which d3d9.dll is found

                    if (d3d9dll_fileFound == "SF") {
                        checkBox_sweetFX.IsChecked = true;
                    }
                }
                
                // GET : SweetFX hotkey -----
                sweetFxKey_gotValue = Functions.GetValueFromFile(SWEET_FX_FILE, "// key_toggle_sweetfx =", 0);

                switch (sweetFxKey_gotValue) {
                    case "145":
                        comboBox_sweetFxKey.SelectedIndex = 0;
                        break;

                    case "114":
                        comboBox_sweetFxKey.SelectedIndex = 1;
                        break;

                    case "noMatch":
                        error = true;
                        where = where + "\"// key_toggle_sweetfx =\" (SweetFX_settings.txt)\n";
                        break;
                }

                // GET : SweetFX preset -----
                if (Directory.Exists(SWEET_FX_PRESET_FOLDER)) {
                    sweetFiles = Directory.GetFiles(SWEET_FX_PRESET_FOLDER);
                    string filename;
                    foreach (string file in sweetFiles) {
                        filename = new FileInfo(file).Name;
                        comboBox_sweetFxPreset.Items.Add(filename);
                    }

                    interm_value = Functions.GetValueFromFile(DATApath + "SweetFX_preset.txt", "#include \"..\\Presets\\", 0);
                    sweetFxPreset_gotValue = interm_value.Substring(0, interm_value.Length - 1);

                    if (sweetFxPreset_gotValue == "noMatch") {
                        error = true;
                        where = where + "\"#include\" (SweetFX_preset.txt)\n";
                    }
                    else {
                        foreach (string value in sweetFiles) {
                            if (value.Contains(sweetFxPreset_gotValue)) {
                                comboBox_sweetFxPreset.Text = sweetFxPreset_gotValue;
                            }
                        }
                    }
                }
                else {
                    MessageBox.Show("Warning : folder ...\\SweetFX\\Presets\\ folder not found :\n\n" + SWEET_FX_PRESET_FOLDER);
                }

                // GET : dvdbnd3 files -----
                checkBox_dvdbnd3Files.IsChecked = true;
                checkBox_dvdbnd3Files.IsChecked = false;
                
                if (Directory.Exists(DVDBND3_FOLDER)) {
                    string[] dvdbnd3SubFolders = Directory.GetDirectories(DVDBND3_FOLDER);
                    string dirname;

                    foreach (string dir in dvdbnd3SubFolders) {
                        if (File.Exists(dir + @"\dvdbnd3.bdt") && File.Exists(dir + @"\dvdbnd3.bhd5")) {
                            dirname = new FileInfo(dir).Name;
                            comboBox_dvdbnd3Files.Items.Add(dirname);
                        }
                    }
                }
                else {
                    //checkBox_dvdbnd3Files.IsEnabled = false;
                    checkBox_dvdbnd3Files.IsEnabled = false;
                    checkBox_dvdbnd3Files.Foreground = (Brush)bc.ConvertFrom("#888");
                }

                checkBox_dvdbnd3Files.IsChecked = true;
                checkBox_dvdbnd3Files.IsChecked = false;

            } // if (modSupport == "normal")

        }

        public void EditFiles() {

            #region Editing DSfix.ini

            // SET : Rendering resolution -----
            int renderWidth_setValue = int.Parse(comboBox_renderRes.Text.Split('x', ' ')[0]);
            int renderHeight_setValue = int.Parse(comboBox_renderRes.Text.Split('x', ' ')[1]);

            if (renderWidth_setValue != renderWidth_gotValue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "renderWidth", 0);
                Functions.LineChanger("renderWidth " + renderWidth_setValue, DS_FIX_INI_FILE, line_to_change);
            }
            if (renderHeight_setValue != renderHeight_gotValue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "renderHeight", 0);
                Functions.LineChanger("renderHeight " + renderHeight_setValue, DS_FIX_INI_FILE, line_to_change);
            }

            // SET : Interface resolution -----
            int presentHeight_setValue;
            int presentWidth_setValue;

            if (comboBox_uiRes.SelectedIndex != 0) {
                presentWidth_setValue = int.Parse(comboBox_uiRes.Text.Split('x', ' ')[0]);
                presentHeight_setValue = int.Parse(comboBox_uiRes.Text.Split('x', ' ')[1]);
            } else {
                presentWidth_setValue = 0;
                presentHeight_setValue = 0;
            }

            if (presentWidth_setValue != presentWidth_gotValue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "presentWidth", 0);
                Functions.LineChanger("presentWidth " + presentWidth_setValue, DS_FIX_INI_FILE, line_to_change);
            }
            if (presentHeight_setValue != presentHeight_gotValue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "presentHeight", 0);
                Functions.LineChanger("presentHeight " + presentHeight_setValue, DS_FIX_INI_FILE, line_to_change);
            }
            
            // SET : Ambient Occlusion strength -----
            int aoStrength_setValue = comboBox_aoStrength.SelectedIndex;
            if (aoStrength_setValue != aoStrength_gotValue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "ssaoStrength", 0);
                Functions.LineChanger("ssaoStrength " + aoStrength_setValue, DS_FIX_INI_FILE, line_to_change);
            }
            
            // SET : Ambient Occlusion type -----
            if (comboBox_aoStrength.SelectedIndex != 0) {

                string aoType_setValue = comboBox_aoType.Text;
                if (aoType_setValue != aoType_gotValue) {
                    line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "ssaoType", 0);
                    Functions.LineChanger("ssaoType " + aoType_setValue, DS_FIX_INI_FILE, line_to_change);
                }
            }
            
            // SET : Depth of Field resolution override -----
            if (comboBox_dofOverrideRes.Text != "") {

                int dofOverrideResolution_setValue = int.Parse(comboBox_dofOverrideRes.Text);
                if (dofOverrideResolution_setValue != dofOverrideResolution_gotValue) {
                    line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "dofOverrideResolution", 0);
                    Functions.LineChanger("dofOverrideResolution " + dofOverrideResolution_setValue, DS_FIX_INI_FILE, line_to_change);
                }
            }
            
            // SET : Depth of Field additional blur -----
            int dofBlurAmount_setValue = comboBox_dofAdditionalBlur.SelectedIndex;
            if (dofBlurAmount_setValue != dofBlurAmount_gotValue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "dofBlurAmount", 0);
                Functions.LineChanger("dofBlurAmount " + dofBlurAmount_setValue, DS_FIX_INI_FILE, line_to_change);
            }
            
            // SET : Unlock framerate -----
            int unlockFPS_setValue = 0;
            if (checkBox_unlockFPS.IsChecked == true) {
                unlockFPS_setValue = 1;
            }
            if (unlockFPS_setValue != unlockFPS_gotValue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "unlockFPS", 0);
                Functions.LineChanger("unlockFPS " + unlockFPS_setValue, DS_FIX_INI_FILE, line_to_change);
            }
            
            // SET : Max framerate -----
            if (comboBox_maxFPSTarget.Text != "") {
                int maxFPS_setValue = int.Parse(comboBox_maxFPSTarget.Text);
                if (maxFPS_setValue != maxFPS_gotValue) {
                    line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "FPSlimit", 0);
                    Functions.LineChanger("FPSlimit " + maxFPS_setValue, DS_FIX_INI_FILE, line_to_change);
                }
            }
            
            // SET : Framerate toggle key -----
            string framerateToggleKey_setValue = framerateToggleKey_gotValue;

            if (comboBox_toggleFramerateKey.SelectedIndex == 0) {
                framerateToggleKey_setValue = "VK_BACK";
            } else if (comboBox_toggleFramerateKey.SelectedIndex == 1) {
                framerateToggleKey_setValue = "VK_F2";
            }

            if (framerateToggleKey_setValue != framerateToggleKey_gotValue) {
                line_to_change = Functions.GetLine(DATApath + "DSfixKeys.ini", "toggle30FPSLimit", 0);
                Functions.LineChanger("toggle30FPSLimit " + framerateToggleKey_setValue, DATApath + "DSfixKeys.ini", line_to_change);
            }
            
            // SET : Force language -----
            string overrideLanguage_setValue = "none";
            switch (comboBox_forceLanguage.SelectedIndex) {
                case 0:
                    overrideLanguage_setValue = "none";
                    break;
                case 1:
                    overrideLanguage_setValue = "en-GB";
                    break;
                case 2:
                    overrideLanguage_setValue = "fr";
                    break;
                case 3:
                    overrideLanguage_setValue = "it";
                    break;
                case 4:
                    overrideLanguage_setValue = "de";
                    break;
                case 5:
                    overrideLanguage_setValue = "es";
                    break;
                case 6:
                    overrideLanguage_setValue = "ko";
                    break;
                case 7:
                    overrideLanguage_setValue = "zh-tw";
                    break;
                case 8:
                    overrideLanguage_setValue = "pl";
                    break;
                case 9:
                    overrideLanguage_setValue = "ru";
                    break;
            }

            if (overrideLanguage_setValue != overrideLanguage_gotValue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "overrideLanguage", 0);
                Functions.LineChanger("overrideLanguage " + overrideLanguage_setValue, DS_FIX_INI_FILE, line_to_change);
            }
            
            // SET : DirectInput wrapper -----
            string dinput8dllWrapper_setValue = dinput8dllWrapper_gotValue;

            if (radioButton_gamepad.IsChecked == true) {
                dinput8dllWrapper_setValue = "none";
            }
            else if (radioButton_mouse.IsChecked == true) {

                if (radioButton_oldMouseFix.IsChecked == true) {
                    dinput8dllWrapper_setValue = "dsmfix.dll";
                } else if (radioButton_newMouseFix.IsChecked == true) {
                    dinput8dllWrapper_setValue = "DarkSoulsMouseFix.dll";
                }
            }

            if (dinput8dllWrapper_setValue != dinput8dllWrapper_gotValue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "dinput8dllWrapper", 0);
                Functions.LineChanger("dinput8dllWrapper " + dinput8dllWrapper_setValue, DS_FIX_INI_FILE, line_to_change);
            }
            
            // SET : Disable mouse cursor -----
            int disableCursor_setValue = 0;
            if (checkBox_showCursor.IsChecked == false) {
                disableCursor_setValue = 1;
            }
            if (disableCursor_setValue != disableCursor_gotvalue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "disableCursor", 0);
                Functions.LineChanger("disableCursor " + disableCursor_setValue, DS_FIX_INI_FILE, line_to_change);
            }
            
            // SET : Capture mouse cursor -----
            int captureCursor_setValue = 0;
            if (checkBox_captureCursor.IsChecked == true) {
                captureCursor_setValue = 1;
            }
            if (captureCursor_setValue != captureCursor_gotValue) {
                line_to_change = Functions.GetLine(DS_FIX_INI_FILE, "captureCursor", 0);
                Functions.LineChanger("captureCursor " + captureCursor_setValue, DS_FIX_INI_FILE, line_to_change);
            }

            #endregion


            #region Editing DarkSouls.ini
            
            // SET : In-game resolution settings -----
            int windowedWidth_setValue, windowedHeight_setValue;
            int fullscreenWidth_setValue, fullscreenHeight_setValue;

            if (renderHeight_setValue < presentHeight_setValue) {
                windowedWidth_setValue = presentWidth_setValue;
                windowedHeight_setValue = presentHeight_setValue;
                fullscreenWidth_setValue = presentWidth_setValue;
                fullscreenHeight_setValue = presentHeight_setValue;
            }
            else if ((renderHeight_setValue > presentHeight_setValue) && (renderHeight_setValue >= 720)) {
                windowedWidth_setValue = renderWidth_setValue;
                windowedHeight_setValue = renderHeight_setValue;
                fullscreenWidth_setValue = renderWidth_setValue;
                fullscreenHeight_setValue = renderHeight_setValue;
            }
            else {
                windowedWidth_setValue = 1920; windowedHeight_setValue = 1080;
                fullscreenWidth_setValue = 1920; fullscreenHeight_setValue = 1080;
            }
            
            // SET : Windowed resolution -----
            int windowedWidth_gotValue = int.Parse(Functions.GetValueFromFile(NBGIfile, "Width =", 0));
            if (windowedWidth_setValue != windowedWidth_gotValue) {
                line_to_change = Functions.GetLine(NBGIfile, "Width", 0);
                Functions.LineChanger("Width = " + windowedWidth_setValue, NBGIfile, line_to_change);
            }
            int windowedHeight_gotValue = int.Parse(Functions.GetValueFromFile(NBGIfile, "Height =", 0));
            if (windowedHeight_setValue != windowedHeight_gotValue) {
                line_to_change = Functions.GetLine(NBGIfile, "Height", 0);
                Functions.LineChanger("Height = " + windowedHeight_setValue, NBGIfile, line_to_change);
            }
            
            // SET : Fullscreen resolution -----
            int fullscreenWidth_gotValue = int.Parse(Functions.GetValueFromFile(NBGIfile, "Width =", 1));
            if (fullscreenWidth_setValue != fullscreenWidth_gotValue) {
                line_to_change = Functions.GetLine(NBGIfile, "Width", 1);
                Functions.LineChanger("Width = " + fullscreenWidth_setValue, NBGIfile, line_to_change);
            }
            int fullscreenHeight_gotValue = int.Parse(Functions.GetValueFromFile(NBGIfile, "Height =", 1));
            if (fullscreenHeight_setValue != fullscreenHeight_gotValue) {
                line_to_change = Functions.GetLine(NBGIfile, "Height", 1);
                Functions.LineChanger("Height = " + fullscreenHeight_setValue, NBGIfile, line_to_change);
            }
            
            // SET : Windowed mode ON -----
            if (int.Parse(Functions.GetValueFromFile(NBGIfile, "WindowMode =", 0)) != 1) {
                line_to_change = Functions.GetLine(NBGIfile, "WindowMode", 0);
                Functions.LineChanger("WindowMode = 1", NBGIfile, line_to_change);
            }
            
            // SET : Blur OFF -----
            if (int.Parse(Functions.GetValueFromFile(NBGIfile, "Blur =", 0)) != 0) {
                line_to_change = Functions.GetLine(NBGIfile, "Blur", 0);
                Functions.LineChanger("Blur = 0", NBGIfile, line_to_change);
            }
            
            // SET : Antialiasing OFF -----
            if (int.Parse(Functions.GetValueFromFile(NBGIfile, "Antialiasing =", 0)) != 0) {
                line_to_change = Functions.GetLine(NBGIfile, "Antialiasing", 0);
                Functions.LineChanger("Antialiasing = 0", NBGIfile, line_to_change);
            }

            #endregion

            if (modSupport == "normal") {

                #region Enabling / disabling SweetFX

                ////////////////////////////////////////////////////////////////////////////////////
                // ENABLING SWEET FX ---------- DLL chaining : Dark Souls > SweetFX > DSPW > ???
                ////////////////////////////////////////////////////////////////////////////////////

                if (checkBox_sweetFX.IsChecked == true) {

                    switch (d3d9dll_fileFound) {
                        case "SF":
                            if (File.Exists(DATApath + "d3d9_sf.dll")) {
                                File.Delete(DATApath + "d3d9_sf.dll"); // delete this file for safety, but do nothing else
                            }
                            break;
                        case "WD":
                            File.Move(DATApath + "d3d9.dll", DATApath + "d3d9_wd.dll");
                            break;
                        default:
                            File.Delete(DATApath + "d3d9.dll"); // deleted if not recognized
                            break;
                    }

                    // If d3d9.dll exists, it's SweetFX. End.
                    // Else :

                    if (!(File.Exists(DATApath + "d3d9.dll"))) {

                        label:

                        if (File.Exists(DATApath + "d3d9_sf.dll")) {
                            // if SweetFX was actually d3d9_sf.dll, we restore it to d3d9.dll :
                            if (Functions.CheckFile(DATApath + "d3d9_sf.dll", "d3d9_dll") == "SF") {
                                File.Move(DATApath + "d3d9_sf.dll", DATApath + "d3d9.dll");
                            }
                            else {
                                File.Delete(DATApath + "d3d9_sf.dll");
                                goto label; // return to label: 
                                // At that point, there isn't any d3d9.dll / d3d9_sf.dll 
                                // so go to the Else statement to copy SweetFX DLL from the Source dir
                            }
                        }
                        else {
                            try {
                                File.Copy(sourceDir + "d3d9.dll", DATApath + "d3d9.dll");
                            } catch (Exception ex) {
                                MessageBox.Show(ex.ToString());
                            }
                        }

                        // d3d9_wd.dll must exist ! If not, copy it :
                        if (!(File.Exists(DATApath + "d3d9_wd.dll"))) {
                            try {
                                File.Copy(sourceDir + "d3d9_wd.dll", DATApath + "d3d9_wd.dll");
                            } catch (Exception ex) {
                                MessageBox.Show(ex.ToString());
                            }
                        }

                        if (File.Exists(SWEET_FX_FILE) && (Functions.GetValueFromFile(SWEET_FX_FILE, "// external_d3d9_wrapper =", 0) != "d3d9_wd.dll")) {
                            line_to_change = Functions.GetLine(SWEET_FX_FILE, "// external_d3d9_wrapper", 0);
                            Functions.LineChanger("// external_d3d9_wrapper = d3d9_wd.dll", SWEET_FX_FILE, line_to_change); // chaining DSPW after SweetFX
                        }

                    }
                    
                    // SET : SweetFX hotkey -----
                    string sweetFxKey_setValue = sweetFxKey_gotValue;

                    if (comboBox_sweetFxKey.SelectedIndex == 0) {
                        sweetFxKey_setValue = "145";
                    } else if (comboBox_sweetFxKey.SelectedIndex == 1) {
                        sweetFxKey_setValue = "114";
                    }

                    if (sweetFxKey_setValue != sweetFxKey_gotValue) {
                        line_to_change = Functions.GetLine(SWEET_FX_FILE, "// key_toggle_sweetfx", 0);
                        Functions.LineChanger("// key_toggle_sweetfx = " + sweetFxKey_setValue, SWEET_FX_FILE, line_to_change);
                    }
                    
                    // SET : SweetFX preset -----
                    string sweetFxPreset_setValue = sweetFxPreset_gotValue;
                    sweetFxPreset_setValue = comboBox_sweetFxPreset.Text;

                    if (sweetFxPreset_setValue != sweetFxPreset_gotValue && sweetFxPreset_setValue != "") {
                        line_to_change = Functions.GetLine(DATApath + "SweetFX_preset.txt", "#include", 0);
                        Functions.LineChanger("#include \"..\\Presets\\" + sweetFxPreset_setValue + "\"", DATApath + "SweetFX_preset.txt", line_to_change);
                    }

                }

                //////////////////////////////////////////////////////////////////////////
                // DISABLING SWEET FX ---------- DLL chaining : Dark Souls > DSPW > ???
                //////////////////////////////////////////////////////////////////////////

                else {
                    switch (d3d9dll_fileFound) {
                        case "SF":
                            File.Move(DATApath + "d3d9.dll", DATApath + "d3d9_sf.dll");
                            break;
                        case "WD":
                            if (File.Exists(DATApath + "d3d9_wd.dll")) {
                                File.Delete(DATApath + "d3d9_wd.dll"); // delete this file for safety, but do nothing else
                            }
                            break;
                        default:
                            File.Delete(DATApath + "d3d9.dll");
                            break;
                    }

                    // If d3d9.dll exists, it's PvP Watchdog. End.
                    // Else :

                    if (!(File.Exists(DATApath + "d3d9.dll"))) { // means if d3d9.dll is NOT DSPW ...

                        label:

                        if (File.Exists(DATApath + "d3d9_wd.dll")) {
                            // if DSPW was actually d3d9_wd.dll, we restore it to d3d9.dll :
                            if (Functions.CheckFile(DATApath + "d3d9_wd.dll", "d3d9_dll") == "WD") {
                                File.Move(DATApath + "d3d9_wd.dll", DATApath + "d3d9.dll");
                            }
                            else {
                                File.Delete(DATApath + "d3d9_wd.dll");
                                goto label; // return to label: 
                                // At that point, there isn't any d3d9.dll / d3d9_wd.dll 
                                // so go to the Else statement to copy DSPW DLL from the Source dir
                            }
                        }
                        else {
                            try {
                                File.Copy(sourceDir + "d3d9_wd.dll", DATApath + "d3d9.dll");
                            } catch (Exception ex) {
                                MessageBox.Show(ex.ToString());
                            }
                        }

                        // d3d9_sf.dll must exist ! If not, copy it :
                        if (!(File.Exists(DATApath + "d3d9_sf.dll"))) {
                            try {
                                File.Copy(sourceDir + "d3d9.dll", DATApath + "d3d9_sf.dll");
                            } catch (Exception ex) {
                                MessageBox.Show(ex.ToString());
                            }
                        }

                    }
                }

                #endregion

                #region Editing DSPWSteam.ini
                
                // Anyway, set this to false :
                if (Functions.GetValueFromFile(DSPW_INI_FILE, "ShowOverlay", 0) != "false") {
                    line_to_change = Functions.GetLine(DSPW_INI_FILE, "ShowOverlay", 0);
                    Functions.LineChanger("ShowOverlay false", DSPW_INI_FILE, line_to_change);
                }

                // SET : DSPW Overlay -----
                string dspwOverlay_setValue = "false";

                if (checkBox_overlayDspw.IsChecked == true) {
                    dspwOverlay_setValue = "true";
                }
                if (dspwOverlay_setValue != dspwOverlay_gotValue) {
                    line_to_change = Functions.GetLine(DSPW_INI_FILE, "ShowVersionBanner", 0);
                    Functions.LineChanger("ShowVersionBanner " + dspwOverlay_setValue, DSPW_INI_FILE, line_to_change);
                }

                #endregion

                #region Editing FPSFix.ini

                // SET : FPSFix enabled -----
                if (checkBox_FPSFix.IsChecked == true) {

                    if (!(File.Exists(DATApath + "winmm.dll"))) {
                        try {
                            File.Move(DATApath + "_winmm.dll", DATApath + "winmm.dll");
                        } catch (Exception ex) {
                            MessageBox.Show(ex.ToString());
                        }
                    }

                    string fpsFixBeep_setValue = fpsFixBeep_gotValue;
                    if (checkBox_FPSFix_beep.IsChecked == true) {
                        fpsFixBeep_setValue = "1";
                    } else {
                        fpsFixBeep_setValue = "0";
                    }
                    if (fpsFixBeep_setValue != fpsFixBeep_gotValue) {
                        line_to_change = Functions.GetLine(FPS_FIX_INI_FILE, "BeepOnDetection=", 0);
                        Functions.LineChanger("BeepOnDetection=" + fpsFixBeep_setValue, FPS_FIX_INI_FILE, line_to_change);
                    }

                }
                else {
                    if (File.Exists(DATApath + "winmm.dll")) {
                        File.Move(DATApath + "winmm.dll", DATApath + "_winmm.dll");
                    }
                }
            }

            #endregion

            #region Gamepad icons
            
            // Long and repetitive but clear code here
            if (radioButton_gamepad.IsChecked == true) {
                try {
                    switch (comboBox_gamepadButtonsStyle.SelectedIndex) {

                        case 0:
                            if (File.Exists(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png")) {
                                File.Delete(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png");
                            }
                            if (File.Exists(DS_FIX_TEXTURE_FOLDER + "43a2b23a.png")) {
                                File.Delete(DS_FIX_TEXTURE_FOLDER + "43a2b23a.png");
                            }
                            break;

                        case 1:
                            if (Functions.CheckFile(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png", "mainButtonsTexture") != "x360") {
                                File.Delete(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png");
                                File.Copy(DS_FIX_TEXTURE_FOLDER + @"Gamepad icons\40fbc4ad_x360.png", DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png");
                            }
                            if (File.Exists(DS_FIX_TEXTURE_FOLDER + "43a2b23a.png")) {
                                File.Delete(DS_FIX_TEXTURE_FOLDER + "43a2b23a.png");
                            }
                            break;

                        case 2:
                            if (Functions.CheckFile(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png", "mainButtonsTexture") != "xbo") {
                                File.Delete(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png");
                                File.Copy(DS_FIX_TEXTURE_FOLDER + @"Gamepad icons\40fbc4ad_xbo.png", DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png");
                            }
                            if (File.Exists(DS_FIX_TEXTURE_FOLDER + "43a2b23a.png")) {
                                File.Delete(DS_FIX_TEXTURE_FOLDER + "43a2b23a.png");
                            }
                            break;

                        case 3:
                            if (Functions.CheckFile(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png", "mainButtonsTexture") != "ps3") {
                                File.Delete(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png");
                                File.Copy(DS_FIX_TEXTURE_FOLDER + @"Gamepad icons\40fbc4ad_ps3.png", DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png");
                            }
                            if (Functions.CheckFile(DS_FIX_TEXTURE_FOLDER + "43a2b23a.png", "otherButtonsTexture") != "ps") {
                                File.Copy(DS_FIX_TEXTURE_FOLDER + @"Gamepad icons\43a2b23a_ps.png", DS_FIX_TEXTURE_FOLDER + "43a2b23a.png");
                            }
                            break;

                        case 4:
                            if (Functions.CheckFile(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png", "mainButtonsTexture") != "ps4") {
                                File.Delete(DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png");
                                File.Copy(DS_FIX_TEXTURE_FOLDER + @"Gamepad icons\40fbc4ad_ps4.png", DS_FIX_TEXTURE_FOLDER + "40fbc4ad.png");
                            }
                            if (Functions.CheckFile(DS_FIX_TEXTURE_FOLDER + "43a2b23a.png", "otherButtonsTexture") != "ps") {
                                File.Copy(DS_FIX_TEXTURE_FOLDER + @"Gamepad icons\43a2b23a_ps.png", DS_FIX_TEXTURE_FOLDER + "43a2b23a.png");
                            }
                            break;

                        default:
                            // Do nothing : keep using the unsupported texture(s)
                            break;
                    }
                }
                catch {
                    MessageBox.Show(Strings.ErrorMsg_controllerButtonTexturesCopyFailed(DS_FIX_TEXTURE_FOLDER, lang));
                }
            }

            #endregion

            //dvdbnd3 files
            if (comboBox_dvdbnd3Files.Text != "") {
                string dvdbnd3_setValue = comboBox_dvdbnd3Files.Text; // get folder name

                if (File.Exists(DATApath + "dvdbnd3.bdt.backup")) {
                    File.Delete(DATApath + "dvdbnd3.bdt.backup");
                }
                if (File.Exists(DATApath + "dvdbnd3.bhd5.backup")) {
                    File.Delete(DATApath + "dvdbnd3.bhd5.backup");
                }

                if (File.Exists(DATApath + "dvdbnd3.bdt")) {
                    File.Move(DATApath + "dvdbnd3.bdt", DATApath + "dvdbnd3.bdt.backup");
                }
                if (File.Exists(DATApath + "dvdbnd3.bhd5")) {
                    File.Move(DATApath + "dvdbnd3.bhd5", DATApath + "dvdbnd3.bhd5.backup");
                }

                try {
                    File.Copy(DVDBND3_FOLDER + dvdbnd3_setValue + @"\dvdbnd3.bdt", DATApath + "dvdbnd3.bdt");
                    File.Copy(DVDBND3_FOLDER + dvdbnd3_setValue + @"\dvdbnd3.bhd5", DATApath + "dvdbnd3.bhd5");
                } catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

    }
}