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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            LayoutXml form2 = new LayoutXml();
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AlignmentReport form3 = new AlignmentReport();
            form3.ShowDialog();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectHtmlForm form = new SelectHtmlForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }
    }
}
