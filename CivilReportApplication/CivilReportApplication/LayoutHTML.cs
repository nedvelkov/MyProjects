using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CivilReportApplication.Models;

namespace CivilReportApplication
{
    public partial class formHtml : Form
    {
        private string filePath;
        private string outputDirectory;
        private string outputName;
        private StringBuilder sb;
        public formHtml()
        {
            InitializeComponent();
        }

        private void rtnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void loadHtml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, Filter = "HTML files|*.html" };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePath = openFileDialog.FileName;
                this.textBox1.Text = StaticMethods.FileName(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Invalid directory");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.outputDirectory = folderBrowserDialog.SelectedPath;
            }

            textBox2.Text = outputDirectory;
        }

        private void crtBtn_Click(object sender, EventArgs e)
        {
            
            var reader = new HtmlReader(filePath);

            this.prBar1.Maximum=reader.ReadHtml();

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                outputName = reader.LayoutName();
            }
            else outputName = textBox3.Text;

            if (string.IsNullOrEmpty(outputDirectory))
            {
                var temp = filePath.LastIndexOf("\\");
                var directory = string.Concat(filePath.Take(temp));
                outputDirectory = directory;
            }

            prBar1.Step = 1;
            prBar1.Value = 0;
            this.sb = new StringBuilder();
            for (int i = 0; i < prBar1.Maximum; i++)
            {
                var dataFromRow = reader.ReadRow(i);
                    this.prBar1.Value = i + 1;
                if (string.IsNullOrEmpty(dataFromRow)) continue;

                sb.AppendLine(dataFromRow);
            }
            ;
            StaticMethods.WriteTxtFile(outputDirectory, outputName, sb);
        }

        private void formHtml_Load(object sender, EventArgs e)
        {
            OnClosed(e);
        }

    }
}
