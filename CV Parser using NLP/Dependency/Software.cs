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
