using CV_Parser_using_NLP.Dependency;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP
{
    public partial class CVForm : Form
    {
        string directory;
        bool updateData = false;
        public CVForm()
        {
            InitializeComponent();
            Enabled = false;
            Helper.InitializeDependencies(LoadingPanel, this);     
            if (updateData)
            {
                Helper.UpdateData();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            if (Directory.Exists(cvDirectoryTextbox.Text)) {

                DirectoryInfo dir = new DirectoryInfo(directory);
                FileInfo[] PDFFiles = dir.GetFiles("*.pdf");
                
                if (!(PDFFiles.Length == 0))
                { 


                                    /*****************/
                    /************/CVParserUsingNLP(PDFFiles);/**************?
                                    /*****************/


                }

                else if (PDFFiles.Length == 0)
                {
                    Helper.ShowError("No CVs found in the directory. Please make sure all CVs are in .PDF format ");
                }

                else {
                    Helper.ShowError("There was an unexpected error. Please try again.");
                }

            }
            else Helper.ShowError("Directory doesn't exist.");
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    directory = folderBrowserDialog.SelectedPath;
                }
                cvDirectoryTextbox.Text = directory;
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }      
        }

        private void CVParserUsingNLP(FileInfo[] PDFFiles)
        {

        }
    }
}
