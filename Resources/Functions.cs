using Microsoft.Win32;
using System.IO;

namespace Resources {

    public class Functions {

        public static string GetValueFromFile(string fileToParse, string keyExpression, int numberOfExpressionToSkip) {

            try {
                using (StreamReader reader = new StreamReader(fileToParse)) {
                    string line;
                    int exprCounter = 0;

                    while ((line = reader.ReadLine()) != null) {
                        if (line.StartsWith(keyExpression)) {
                            if (exprCounter == numberOfExpressionToSkip) {
                                if (line.Length > keyExpression.Length) {

                                    line = line.Substring(keyExpression.Length); // Remove the key from the line, to get the value only

                                    if (line.Substring(0, 1) == " ") {
                                        line = line.Substring(1); // Remove the blank space before the value, if it exists
                                    }
                                    if (line.Substring(line.Length - 1) == " ") {
                                        line = line.Substring(0, line.Length - 1); // Remove the blank space at the end if it exist
                                    }
                                    return line; // Return the modified line. That's the value we want

                                }
                                else {
                                    return "noValue"; // If the line isn't longer than the key = no value to be read
                                }
                            }
                            exprCounter++;
                        }
                    }
                    return "noMatch"; // If lineBeginning is not found
                }
            }
            catch {
                return "Error parsing the file";  // It probably won't be used, that's just for the code clarity
            }

        }

        public static int GetLine(string fileToParse, string expression, int numberOfExpressionToSkip) {

            try {
                using (StreamReader reader = new StreamReader(fileToParse)) {
                    string line;
                    int line_counter = 0;
                    int expr_counter = 0;

                    while ((line = reader.ReadLine()) != null) {
                        line_counter++;

                        if ((line.StartsWith(expression))) {
                            if (expr_counter == numberOfExpressionToSkip) {
                                return line_counter; // If expression found, return its line number
                            }
                            expr_counter++;
                        }
                    }
                    return 0; // If expression not found, return 0. LineChanger function won't deal with 0 (no crash)
                }
            }
            catch {
                return 0;
            }

        }

        public static void LineChanger(string newText, string fileName, int line_to_edit) {

            // Originally copied from : http://stackoverflow.com/questions/1971008/edit-a-specific-line-of-a-text-file-in-c-sharp

            if (line_to_edit != 0) {
                string[] arrLine = File.ReadAllLines(fileName);
                arrLine[line_to_edit - 1] = newText;
                File.WriteAllLines(fileName, arrLine);
            }
        }

        public static string CheckFile(string file, string fileType) {
            FileInfo file_info = new FileInfo(file);

            switch (fileType) {
                case "d3d9_dll":
                    try {
                        switch (file_info.Length) {
                            case 62464:
                                return "SF";
                            case 227328:
                                return "WD";
                            default:
                                return "unsupported";
                        }
                    }
                    catch {
                        return "noFileFound";
                    }

                case "mainButtonsTexture":
                    try {
                        switch (file_info.Length) {
                            case 137971:
                                return "x360";
                            case 132047:
                                return "xbo";
                            case 134781:
                                return "ps3";
                            case 283442:
                                return "ps4";
                            default:
                                return "unsupported";
                        }
                    }
                    catch {
                        return "noFileFound";
                    }

                case "otherButtonsTexture":
                    try {
                        if (file_info.Length == 206315) {
                            return "ps";
                        }
                        return "unsupported";
                    }
                    catch {
                        return "noFileFound";
                    }
                default:
                    return "";
            }
        }

        public static string GetDataFolderPathWithRegistry() {

            // TODO : Tests, other keys/values implementation

            // Other possible registry keys/values :
            // @"SOFTWARE\Wow6432Node\namco bandai games\dark souls" / "exe_path"
            // @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 211420" / "InstallLocation"

            string keyValue = "";
            RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey regKey = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 211420");

            if (regKey != null)
                keyValue = regKey.GetValue("InstallLocation").ToString();
            if (Directory.Exists(keyValue))
                return keyValue + @"\DATA\";
            return "";

        }

        public static string GetSteamFolderPathWithRegistry() {

            string keyValue = "";
            RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey regKey = baseKey.OpenSubKey(@"SOFTWARE\Wow6432Node\Valve\Steam");

            if (regKey != null)
                keyValue = regKey.GetValue("InstallPath").ToString();
            if (Directory.Exists(keyValue))
                return keyValue + @"\";
            return "";
        }

        public static string ParseDataPathValue(string file, string expression) {

            string chosenPath = GetValueFromFile(file, expression, 0);

            if (Directory.Exists(chosenPath))
                return chosenPath;
            return "";
        }

        public static string ParseLauncherPath(string file, string expression, int elementsToSkip, int charToCut) {

            string path = GetValueFromFile(file, expression, elementsToSkip);
            string editedPath = path.Substring(0, path.Length - charToCut);

            if (File.Exists(editedPath))
                return editedPath;
            return "";
        }

        public static bool CheckPath(string path) {

            if (File.Exists(path + "fmodex.dll") && File.Exists(path + "fmod_event.dll"))
                return true;
            return false;
        }

    }
}
