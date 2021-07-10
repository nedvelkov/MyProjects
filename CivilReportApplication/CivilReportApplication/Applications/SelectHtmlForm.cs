namespace CivilReportApplication
{
    using System;
    using System.Windows.Forms;

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
