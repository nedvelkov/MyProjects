namespace CivilReportApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using CivilReportApplication.DtoExportModels;
    using CivilReportApplication.Models;

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
            progress+=2;
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

            int starRow = 5;
            int endRow = 5 + report.Count - 1;
            int startColm = 1;
            int endColm = 7;
            writer.FormatTable(starRow, endRow, startColm, endColm);
            writer.FormatStationColm(starRow, endRow, 1);

            writer.CreateFile(outputDirectory, "ter", reportName);

            DialogResult res = MessageBox.Show("Report created. Do you want to open report", "Sucsseful", MessageBoxButtons.YesNo);


            if (res == DialogResult.Yes)
            {

                System.Diagnostics.Process.Start($"{outputDirectory}\\ter_{reportName}.xls");

            }

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
