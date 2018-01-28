using CV_Parser_using_NLP.Data;
using CV_Parser_using_NLP.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP
{
    public partial class CVForm : Form
    {
        string directory;
        Parser parser;
        bool updateData = false;
        public CVForm()
        {
            InitializeComponent();
            FormPanel.Enabled = false;
            Helper.InitializeDependencies(LoadingPanel, FormPanel);     
            if (updateData)
            {
                Helper.UpdateData();
            }
        }

        private void CVForm_Load(object sender, EventArgs e)
        {
            WindowState = Properties.Settings.Default.CVFormState;
            Size = Properties.Settings.Default.CVFormSize;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    directory = folderBrowserDialog.SelectedPath;
                    parser = new Parser(directory);
                }
                cvDirectoryTextbox.Text = directory;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string skills = skillsTextbox.Text;
            string education = educationQualificationTextbox.Text;
            string experience = experienceTextBox.Text;

            if (skills != "" && education != "" && experience != "")
            {
                if (Directory.Exists(directory))
                {

                    DirectoryInfo dir = new DirectoryInfo(directory);
                    FileInfo[] PDFFiles = dir.GetFiles("*.pdf");

                    if (!(PDFFiles.Length == 0))
                    {

                                //ENTRY POINT OF THE PARSING ENGINE//
                                        /*****************/
                        /************/CVParserUsingNLP();/*************/
                                      /*****************/


                    }
                    if (PDFFiles.Length == 0)
                    {
                        Helper.ShowError("No CVs found in the directory. Please make sure all CVs are in .PDF format ");
                    }
                }
                else Helper.ShowError("Directory doesn't exist.");
                                
            }
            else Helper.ShowError("All fields are required.");           
        }

        private async void CVParserUsingNLP()
        {
            //DISABLE THE FORM PANEL ENABLE LOAD PANEL
            Helper.LoadLoadingPanel(LoadingPanel, FormPanel, WaitLabel, "Hang on while we find the best CV for you");

            //INITIALIZE REQUIREMENT DATA FROM UI
            parser.InitializeRequirementData(skillsTextbox.Text, experienceTextBox.Text, educationQualificationTextbox.Text);

            //GET ALL CV DATA AS DICTIONARY(FILENAME: CONTENT)           
            Dictionary<string, List<string>> EntireCVData = await Task.Run(() => parser.GetPDFFilesData());

            if (EntireCVData != null)
            {
                //INITIALIZE CV CONTENT FOR EACH FILENAME WHICH RETURNS QUEUE OF CVDATA INSTANCES
                Queue<CVData> cvData = await Task.Run(()=>parser.InitializeCVData(EntireCVData));

                if (cvData != null)
                {
                    //COMPARE CV DATA WITH REQUIREMENT DATA AT PARSING ENGINE
                    Dictionary<string, double> cvScores = await Task.Run(() => parser.CompareCVDataToRequiredData(cvData));
                    
                    if(cvScores != null)
                    {
                        //RANK CVs IN HIGHEST ORDER OF SCORE
                        Dictionary<string, double> rankedCVs= await Task.Run(() => parser.RankCVs(cvScores));

                        if (rankedCVs != null)
                        {
                            //DISPLAY RANKED CVs IN UI
                            parser.DisplayRankedCVs(rankedCVs, CVTable);

                            //RELOAD THE FORM
                            Helper.LoadFormPanel(LoadingPanel, FormPanel);
                        }
                    }
                    else
                    {
                        Helper.ShowError("An unexpected error occured. Please try again later.");
                    }
                }
                else
                {
                    Helper.ShowError("An unexpected error occured. Please try again later.");
                }
            }
            else
            {
                Helper.ShowError("None of the CVs could be parsed. Please try valid set of CVs.");
            }

            //DELETING ALL TEMP FILES CREATED
            Helper.DeleteTempFiles();

        }
    }
}
