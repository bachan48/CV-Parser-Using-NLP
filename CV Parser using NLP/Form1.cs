using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void educationQualificationTextbox_TextChanged(object sender, EventArgs e)
        {
            educationQualificationTextbox.Text = "";
        }
    }
}
