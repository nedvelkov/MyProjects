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
    public partial class SurfaceProfileReport : Form
    {
        public SurfaceProfileReport()
        {
            InitializeComponent();
        }

        private string filePath;
        private string outputDirectory;

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
                return;
            }
        }

        private void saveLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.outputDirectory = folderBrowserDialog.SelectedPath;
            }

            textBox2.Text = outputDirectory;
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form1 = new MainForm();
            form1.ShowDialog();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            var reader = new HtmlReader(filePath);
            reader.ReadHtml();
            this.progressBar1.Maximum = reader.TotalRows() * 2 + 1;
            this.progressBar1.Step = 1;
            this.progressBar1.Value = 0;
            var report = new List<SurfaceProfileReportDto>();
            for (int i = 1; i < reader.TotalRows(); i++)
            {
                ;
                var row = reader.ReadRow(i, true).Split(',');
                var dto = ReadRow(row);
                if (dto.PointName == "Regular")
                {
                    dto.PointName = "";
                }
                report.Add(dto);
                this.progressBar1.Value = i + 1;
            }



            var writer = new ExcelWriter(outputDirectory);
            writer.CreateWorkbook();
            var headingsColum = new string[] { "КМ", "X", "Y", "Кота терен", "Кота нивлета", "Рабона разлика", "Точка" };
            var progress = this.progressBar1.Value;
            progress++;
            this.progressBar1.Value = progress;
            writer.AddRow(headingsColum, 4);
            for (int i = 0; i < report.Count; i++)
            {
                var currentRow = report[i];
                writer.AddRow(currentRow, 5 + i);

                this.progressBar1.Value = progress + 1 + i;
            }

            if (string.IsNullOrEmpty(outputDirectory))
            {
                var temp = filePath.LastIndexOf("\\");
                var directory = string.Concat(filePath.Take(temp));
                outputDirectory = directory;
            }
            var reportName = textBox3.Text;
            if (string.IsNullOrEmpty(this.textBox3.Text))
            {
                reportName = reader.LayoutName();
            }
            writer.AddHeading($"Данни за терена за {reportName}", 7);
            if (checkBox1.Checked)
            {
                writer.AddHeader(this.textBox4.Lines);
            }

            if (checkBox2.Checked)
            {
                writer.AddFooter(reportName);
            }
            writer.CreateFile(outputDirectory, "ter", reportName);
            ;
        }

        private SurfaceProfileReportDto ReadRow(string[] array)
        {
            var dto = new SurfaceProfileReportDto();
            dto.Station = double.Parse(array[1].Replace("+", ""));
            dto.Easting = double.Parse(array[2]);
            dto.Northing = double.Parse(array[3]);
            dto.PointName = array[7];
            if (string.IsNullOrEmpty(array[4]) == false)
            {
                dto.ElevationSurface = double.Parse(array[4].Replace("m", ""));
            }
            if (string.IsNullOrEmpty(array[5]) == false)
            {
                dto.ElevationProfile = double.Parse(array[5].Replace("m", ""));
            }

            return dto;
        }
    }
}
