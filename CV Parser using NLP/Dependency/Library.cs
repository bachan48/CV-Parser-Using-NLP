using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP.Dependency
{
    class Library
    {
        public static bool InstallGemAnemone(string gemName){
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.Arguments = @"/c gem install " + gemName;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.Start();
            cmd.WaitForExit();
            return true;
        }

        public static bool InstallLibraryNLTK(string libraryName){            
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.Arguments = @"/c py -m pip install nltk";
            cmd.Start();
            cmd.WaitForExit();
            return true;
        }
    }
}
