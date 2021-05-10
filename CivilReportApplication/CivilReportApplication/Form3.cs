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
    public partial class Form3 : Form
    {
        private string filePath;
        private string outputDirectory;
        private List<AlignmentReportDto> exportDto;

        public Form3()
        {
            InitializeComponent();
        }

        private void rtnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form1 = new MainForm();
            form1.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                var reader = new XmlReader(filePath);
                var allRows = reader.ReadFile("CoordGeom");
                this.progressBar1.Maximum = allRows;
                this.progressBar1.Step = 1;
                this.progressBar1.Value = 0;
                this.exportDto = new List<AlignmentReportDto>();
                for (int i = 0; i < allRows; i++)
                {
                   var dto= reader.ReadRow(i);
                    this.exportDto.Add(dto);
                    progressBar1.Value = i + 1;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Invalid xml file");
                return;
            }



        }

        private void loadXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, Filter = "XML files|*.xml" };

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
