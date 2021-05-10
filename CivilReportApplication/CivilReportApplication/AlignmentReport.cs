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
    public partial class AlignmentReport : Form
    {
        private string filePath;
        private string outputDirectory;
        private string reportName;
        private int countInfo;
        private List<AlignmentReportDto> exportDto;

        public AlignmentReport()
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
                reader.ReadFile("CoordGeom");
                this.reportName = reader.ReportName("CoordGeom");
                this.countInfo = reader.CountReportInfo();
                this.progressBar1.Maximum = countInfo*2+1;
                this.progressBar1.Step = 1;
                this.progressBar1.Value = 0;
                this.exportDto = new List<AlignmentReportDto>();
                for (int i = 0; i < countInfo; i++)
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

            var wrtier = new ExcelWriter(outputDirectory);
            wrtier.CreateWorkbook();
            var headingsColum = new string[] { "Nо", "Тип", "Начален км", "Краен км", "Дължина", "Радиус", "А", "Полигонов ъгъл", "Начална точка", "Крайна точка" };
            var progress = this.progressBar1.Value;
            progress++;
            this.progressBar1.Value = progress;
            wrtier.AddRow(headingsColum, 4);
            for (int i = 0; i < countInfo; i++)
            {
                var currentRow = this.exportDto[i];
                wrtier.AddRow(currentRow, 5 + i);

                this.progressBar1.Value = progress + 1 + i;
            }

            if (string.IsNullOrEmpty(outputDirectory))
            {
                var temp = filePath.LastIndexOf("\\");
                var directory = string.Concat(filePath.Take(temp));
                outputDirectory = directory;
            }
            if (string.IsNullOrEmpty(this.textBox3.Text) == false)
            {
                this.reportName = textBox3.Text;
            }
            wrtier.AddHeading($"Данни за ситуация за {reportName}");
            if (checkBox1.Checked)
            {
                wrtier.AddHeader(this.txtBox4.Lines);
            }

            if (checkBox2.Checked)
            {
                wrtier.AddFooter(reportName);
            }
            wrtier.CreateFile(outputDirectory,"sit" ,reportName);

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
