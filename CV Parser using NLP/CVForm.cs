using CV_Parser_using_NLP.Dependency;
using System;
using System.IO;
using System.Windows.Forms;

namespace CV_Parser_using_NLP
{
    public partial class CVForm : Form
    {
        public CVForm()
        {
            InitializeComponent();
            bool isPythonInstalled = Software.CheckSoftwareInstalled("Python 3.6");
            bool isRubyInstalled = Software.CheckSoftwareInstalled("Ruby 2.4.3");

            if (!isRubyInstalled)
                MessageBox.Show("We did not find Ruby in your computer. Ruby is requred to run this software. Please install Ruby 2.4.3 or greater from a web browser.");

            if (!isPythonInstalled)
                MessageBox.Show("We did not find Python in your computer. Python is requred to run this software. Please install Python 3.6 or greater from a web browser.");

            if (isPythonInstalled && isRubyInstalled) {
                Library.InstallGemAnemone("anemone");
                Library.InstallLibraryNLTK("NLTK");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(cvDirectoryTextbox.Text)) {
                
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
