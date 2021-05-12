using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CivilReportApplication
{
    public partial class SelectHtmlForm : Form
    {
        public SelectHtmlForm()
        {
            InitializeComponent();
        }

        public string ReportType { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ReportType = "Layout";
            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ReportType = "Coridor";
            this.Close();


        }
    }
}
