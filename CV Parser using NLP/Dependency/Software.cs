using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP.Dependency
{
    public class Software
    {
        public static bool InitializeDependencies()
        {            
            bool isPythonInstalled = Software.CheckSoftwareInstalled("Python");
            bool isRubyInstalled = Software.CheckSoftwareInstalled("Ruby");           

            if (!isPythonInstalled)
            {
                Helper.ShowError("We did not find Python in your computer. Python is required to run this software. Please install Python 3.6 or greater from a web browser.");
                return false;
            }
            if (!isRubyInstalled)
            {
                Helper.ShowError("We did not find Ruby in your computer. Ruby is required to run this software. Please install Ruby 2.4.3 or greater from a web browser.");
                return false;
            }
            if (isPythonInstalled && isRubyInstalled)
            {               
                try
                {
                    var assembly = Assembly.GetExecutingAssembly();

                    var resourceName1 = "CV_Parser_using_NLP.Dependency.Script.InstallPyLibrary.py";
                    byte[] file1 = ResourceHelper.GetEmbeddedResourceAsBytes(resourceName1);
                    File.WriteAllBytes(@"C:\Windows\Temp\InstallPyLibrary.py", file1);

                    var resourceName2 = "CV_Parser_using_NLP.Dependency.Script.pdf_to_textfile.py";
                    byte[] file2 = ResourceHelper.GetEmbeddedResourceAsBytes(resourceName2);
                    File.WriteAllBytes(@"C:\Windows\Temp\pdf_to_textfile.py", file2);

                    Library.InstallGemAnemone("anemone");
                    Library.InstallLibraryNLTK("NLTK");
                    Library.InstallPyLibrary(@"C:\Windows\Temp\InstallPyLibrary.py");

                    Helper.ShowInformation("Thank you for your patience, we're good to go!");
                    return true;
                }
                catch
                {
                    Helper.ShowError("Error accessing resources!");
                    Application.Exit();                    
                }               
            }
            return false;
        }
        public static bool CheckSoftwareInstalled(string softwareName)
        {
            bool isSotwareInstalledLocal = IsSoftwareInstalledLocalMachine(softwareName);
            bool isSotwareInstalledUser = IsSoftwareInstalledCurrentUser(softwareName);

            if (isSotwareInstalledLocal || isSotwareInstalledUser)
            {
                return true;
            }
            return false;
        } 

        public static bool IsSoftwareInstalledLocalMachine(string softwareName)
        {
            try
            {
                var LocalMachineKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ??
                      Registry.LocalMachine.OpenSubKey(
                          @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");

                if (LocalMachineKey == null)
                    return false;

                return LocalMachineKey.GetSubKeyNames()
                        .Select(keyName => LocalMachineKey.OpenSubKey(keyName))
                        .Select(subkey => subkey.GetValue("DisplayName") as string)
                        .Any(displayName => displayName != null && displayName.Contains(softwareName));
            }
            catch (Exception ex)
            {
                Helper.ShowError(ex.Message);
                return false;
            }
        }

        public static bool IsSoftwareInstalledCurrentUser(string softwareName)
        {
            try
            {
                var CurrentUserKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ??
                      Registry.CurrentUser.OpenSubKey(
                          @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");

                if (CurrentUserKey == null)
                    return false;
                
                return CurrentUserKey.GetSubKeyNames()
                    .Select(keyName => CurrentUserKey.OpenSubKey(keyName))
                    .Select(subkey => subkey.GetValue("DisplayName") as string)
                    .Any(displayName => displayName != null && displayName.Contains(softwareName));
            }
            catch (Exception ex)
            {
                Helper.ShowError(ex.Message);
                return false;
            }
        }
    }
}
