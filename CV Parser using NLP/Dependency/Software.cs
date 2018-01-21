using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP.Dependency
{
    public class Software
    {
        public static bool InitializeDependencies()
        {            
            bool isPythonInstalled = Software.CheckSoftwareInstalled("Python 3.6");
            bool isRubyInstalled = Software.CheckSoftwareInstalled("Ruby 2.4.3");           

            if (!isPythonInstalled)
            {
                MessageBox.Show("We did not find Python in your computer. Python is requred to run this software. Please install Python 3.6 or greater from a web browser.");
                return false;
            }
            if (!isRubyInstalled)
            {
                MessageBox.Show("We did not find Ruby in your computer. Ruby is requred to run this software. Please install Ruby 2.4.3 or greater from a web browser.");
                return false;
            }
            if (isPythonInstalled && isRubyInstalled)
            {
                /*await Task.Run(()=> (Library.InstallGemAnemone("anemone")));
                await Task.Run(() => (Library.InstallLibraryNLTK("NLTK")));*/
                Library.InstallGemAnemone("anemone");
                Library.InstallLibraryNLTK("NLTK");
                var dialogResult = MessageBox.Show("Thank you for your patience, we're good to go!");
                return true;
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
