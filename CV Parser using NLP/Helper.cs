using CV_Parser_using_NLP.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_Parser_using_NLP
{
    class Helper
    {
        public async void InitializeDependencies(ProgressBar bar, Form form)
        {
            var result = await Task.Run(() => (Software.InitializeDependencies()));
            if (result)
            {
                form.Enabled = true;
                bar.Visible = false;
                bar.Enabled = false;
            }
            if (!result)
            {
                Application.Exit();
            }
        }
    }
}
