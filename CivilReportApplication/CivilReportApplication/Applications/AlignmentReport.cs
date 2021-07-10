namespace CivilReportApplication
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using CivilReportApplication.DtoExportModels;
    using CivilReportApplication.Models;

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

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form1 = new MainForm();
            form1.ShowDialog();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                var reader = new XmlReader(filePath);
                reader.ReadFile("CoordGeom");
                this.reportName = reader.ReportName("CoordGeom");
                this.countInfo = reader.CountReportInfo();
                this.progressBar1.Maximum = countInfo * 2 + 1;
                this.progressBar1.Step = 1;
                this.progressBar1.Value = 0;
                this.exportDto = new List<AlignmentReportDto>();
                for (int i = 0; i < countInfo; i++)
                {
                    var dto = reader.ReadRow(i);
                    this.exportDto.Add(dto);
                    progressBar1.Value = i + 1;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Invalid xml file");
                return;
            }

            if (string.IsNullOrEmpty(outputDirectory))
            {
                var temp = filePath.LastIndexOf("\\");
                var directory = string.Concat(filePath.Take(temp));
                outputDirectory = directory;
            }
            var writer = new ExcelWriter(outputDirectory);
            writer.CreateWorkbook();
            var headingsColum = new string[] { "Nо", "Тип", "Начален км", "Краен км", "Дължина", "Радиус", "А", "Полигонов ъгъл", "Начална точка", "Крайна точка" };
            var progress = this.progressBar1.Value;
            progress++;
            this.progressBar1.Value = progress;
            writer.AddRow(headingsColum, 4);
            for (int i = 0; i < countInfo; i++)
            {
                var currentRow = this.exportDto[i];
                writer.AddRow(currentRow, 5 + i);

                this.progressBar1.Value = progress + 1 + i;
            }

            if (string.IsNullOrEmpty(this.textBox3.Text) == false)
            {
                this.reportName = textBox3.Text;
            }
            writer.AddHeading($"Данни за ситуация за {reportName}", 10);
            if (checkBox1.Checked)
            {
                writer.AddHeader(this.txtBox4.Lines);
            }

            if (checkBox2.Checked)
            {
                writer.AddFooter(reportName);
            }
            int starRow = 5;
            int endRow = 5 + countInfo - 1;
            int startColm = 1;
            int endColm = 10;
            writer.FormatTable(starRow, endRow, startColm, endColm);
            writer.FormatStationColm(starRow, endRow, 3);
            writer.FormatStationColm(starRow, endRow, 4);
            writer.CreateFile(outputDirectory, "sit", reportName);


            DialogResult res = MessageBox.Show("Report created. Do you want to open report", "Sucsseful", MessageBoxButtons.YesNo);


            if (res == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start($"{outputDirectory}\\sit_{reportName}.xls");
            }

        }

        private void LoadXml_Click(object sender, EventArgs e)
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

        private void SaveBtn_Click(object sender, EventArgs e)
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
