using CV_Parser_using_NLP.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Helper.InitializeTrainingData();                
                Application.Run(new CVForm());                
            }
            catch(Exception ex)
            {
                Helper.ShowError(ex.Message);
            }
           
        }
    }
}
