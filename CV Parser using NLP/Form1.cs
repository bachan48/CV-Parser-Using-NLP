using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
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
    }
}
