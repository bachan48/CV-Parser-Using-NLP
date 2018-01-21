using CV_Parser_using_NLP.Dependency;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP
{
    public partial class CVForm : Form
    {
        public CVForm()
        {
            InitializeComponent();
            Enabled = false;
            Helper helper = new Helper();
            helper.InitializeDependencies(InitProgressBar, this);

            /*var result = MessageBox.Show("This program requires installation of Python, Ruby and their dependencies. By pressing OK you agree to automatic installation of these dependencies.");
            if (result == DialogResult.OK){
                helper.InitializeDependencies(InitProgressBar, this);
            }*/
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
