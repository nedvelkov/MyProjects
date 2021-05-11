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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private GeometryReportProfile form;
        public static RichTextBox RichTextBox = new RichTextBox();

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form1 = new MainForm();
            form1.ShowDialog();
        }


        private void readBtn_Click(object sender, EventArgs e)
        {
            var report = RichTextBox.Lines;
            var readReport = new List<string[]>();
            foreach (var item in report)
            {
                var currentRow = item.Split('\t');
                readReport.Add(currentRow);
                ;
            }

            ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.form = new GeometryReportProfile();
        }
    }
}
