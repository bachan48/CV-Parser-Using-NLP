using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP
{
    public partial class CVForm : Form
    {
        public CVForm()
        {
            InitializeComponent();
            CheckSoftwareInstalled("Python");
            CheckSoftwareInstalled("Ruby");
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(cvDirectoryTextbox.Text)) {
                Console.WriteLine("Check. Ok.");
            }
            else MessageBox.Show("Dir doesn't exist");    

        }       

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = "";
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderBrowserDialog.SelectedPath;
                }
                cvDirectoryTextbox.Text = folderPath;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void CheckSoftwareInstalled(string softwareName)
        {
            bool isSotwareInstalledLocal = IsSoftwareInstalledLocalMachine(softwareName);
            bool isSotwareInstalledUser = IsSoftwareInstalledCurrentUser(softwareName);

            if (isSotwareInstalledLocal || isSotwareInstalledUser)
            {
                Console.WriteLine("Installed.");
            }
            else
            {
                MessageBox.Show(softwareName+ " is requred to run this software. Please install "+softwareName+" from a web browser");
            }
        }

        private static bool IsSoftwareInstalledLocalMachine(string softwareName)
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static bool IsSoftwareInstalledCurrentUser(string softwareName) {
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
