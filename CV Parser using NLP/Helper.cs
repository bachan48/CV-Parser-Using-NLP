using CV_Parser_using_NLP.Data;
using CV_Parser_using_NLP.Dependency;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP
{
    class Helper
    {        
        public static async void InitializeDependencies(Panel panel, Form form)
        {
            var result = await Task.Run(() => (Software.InitializeDependencies()));
            bool connectivity = CheckForInternetConnection();
            if (result && connectivity)
            {
                form.Enabled = true;
                panel.Visible = false;
                panel.Enabled = false;
                form.BackColor = Color.FromArgb(0, 64, 128);
            }
            if (!result || !connectivity)
            {
                Application.Exit();
            }
        }

        public static void InitializeTrainingData()
        {
            List<Object> SkillDictionary = new List<Object>();
            List<Object> ExperienceDictionary = new List<Object>();
            List<Object> EducationDictionary = new List<Object>();
            AddData(SkillDictionary, "skills");
            AddData(ExperienceDictionary, "experience");
            AddData(EducationDictionary, "education");

            RequirementData data = new RequirementData(SkillDictionary, ExperienceDictionary, EducationDictionary);
        }

        public static void InitializeRequirementData()
        {

        }

        public static bool AddData(List<Object> Dictionary, string file)
        {
            try
            {

                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "CV_Parser_using_NLP.Data.DataSet."+file+".txt";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string names = reader.ReadToEnd();

                    List<string> result = names.Split(new char[] { '\n' }).ToList();
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
