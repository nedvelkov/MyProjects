using CivilReportApplication.DtoExportModels;
using CivilReportApplication.Models;
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

        private string filePath;
        private string outputDirectory;

        private HtmlReader reader;
        private Dictionary<PointReport, int> codes;



        private void loadBtn_Click(object sender, EventArgs e)
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
                return;
            }

            this.reader = new HtmlReader(filePath);
            this.codes = reader.PointCodesReport();

            foreach (var code in codes)
            {
                this.checkedListBox1.Items.Add(code.Key.Code);
            }
            var temp = new string[] { "Offset", "Elevation", "Slope", "Easting", "Northing", };
            this.checkedListBox2.Items.AddRange(temp);
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
    }
}
