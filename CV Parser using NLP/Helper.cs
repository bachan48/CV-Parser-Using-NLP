using CV_Parser_using_NLP.Dependency;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP
{
    class Helper
    {
        public static async void InitializeDependencies(Panel loadingPanel, Panel formPanel)
        {
            var result = await Task.Run(() => (Software.InitializeDependencies()));
            bool connectivity = CheckForInternetConnection();
            if (result && connectivity)
            {
                LoadFormPanel(loadingPanel, formPanel);
            }
            if (!result || !connectivity)
            {
                Application.Exit();
            }
        }
        
        public static bool AddDataFromResource(List<string> Dictionary, string file)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "CV_Parser_using_NLP.Data.DataSet."+file+".txt";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string retrivedNames = reader.ReadToEnd();
                    string names = retrivedNames.ToUpper();
                    string[] result = names.Split(
                        new[] { "\r\n", "\r", "\n" }, 
                        StringSplitOptions.None
                    );                    
                    foreach (var data in result)
                    {
                        Dictionary.Add(data);
                    }
                }
                return true;
            }
            catch
            {
                ShowError("Error accessing resources!");
                return false;
            }
        }

        public static Dictionary<string, List<string>> GetPDFFilesData(string directory)
        {
            try
            {
                Dictionary<string, List<string>> EntireCVData = new Dictionary<string, List<string>>();

                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                cmd.StartInfo.Arguments = @"/c py C:\Windows\Temp\pdf_to_textfile.py " + "\"" + directory + "\"";
                cmd.Start();
                cmd.WaitForExit();

                var txtFiles = Directory.EnumerateFiles(@"C:\Windows\Temp\temp", "*.txt");
                foreach (string currentFile in txtFiles)
                {
                    List<string> CVDataList = new List<string>();
                    using (StreamReader streamReader = new StreamReader(currentFile))
                    {
                        string retrivedItems = streamReader.ReadToEnd();
                        string items = retrivedItems.ToUpper();
                        List<string> result = items.Split(new char[] { ',' }).ToList();
                        foreach (var data in result)
                        {
                            CVDataList.Add(data);
                        }
                    }
                    Console.WriteLine("");
                    EntireCVData.Add(currentFile, CVDataList);
                }
                return EntireCVData;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            return null;
        }

        public static double GetSimilarityPercentage(List<string> list1, List<string> list2)
        {
            try
            {
                string[] matchingData = list1.Intersect(list2).ToArray();
                double percentage = (double)matchingData.Count() / list2.Count() * 100;
                return percentage;
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
            }
            return -1;             
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                ShowError("There seems to be no internet connection. Please check your internet connection and try again.");
                return false;                
            }
        }

        public static int GetEmptyRowIndex(DataGridView DataGridView)
        {
            int rows = DataGridView.RowCount;
            int columns = DataGridView.ColumnCount;
            int nextRow = 0;
            int nextCol = 0;
            bool flag = false;
            do
            {
                string value = (string)DataGridView.Rows[nextRow].Cells[nextCol].Value;
                if (value != null && value.Length != 0) nextRow++;
                else flag = true;
            } while (!flag && nextRow < rows);
            return nextRow;
        }

        public static void LoadFormPanel(Panel loadingPanel, Panel formPanel)
        {
            formPanel.Enabled = true;
            loadingPanel.Visible = false;
            loadingPanel.Enabled = false;
            formPanel.BackColor = Color.FromArgb(0, 64, 128);
        }

        public static void LoadLoadingPanel(Panel loadingPanel, Panel formPanel, Label label, string message)
        {
            formPanel.Enabled = false;
            loadingPanel.Visible = true;
            loadingPanel.Enabled = true;
            label.Text = message;
            formPanel.BackColor = Color.WhiteSmoke;
        }

        public static void ShowError(string message) {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformation(string message)
        {
            MessageBox.Show(message,"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool UpdateData()
        {
            return false;
        }

    }
}