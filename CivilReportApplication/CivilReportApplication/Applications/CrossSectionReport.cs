using CivilReportApplication.DtoExportModels;
using CivilReportApplication.DtoImportModels;
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
    public partial class CrossSectionReport : Form
    {
        public CrossSectionReport()
        {
            InitializeComponent();
        }

        private string filePath;
        private string outputDirectory;

        private HtmlReader reader;
        private List<PointFromCrossSection> codes;



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

            using (CodesInCrossSection form2 = new CodesInCrossSection())
            {
                form2.codes = this.codes;
                form2.ShowDialog();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.codes == null)
            {
                MessageBox.Show("Chose HTML file first");
                return;
            }
            using (CodesInCrossSection form2 = new CodesInCrossSection())
            {
                form2.codes = this.codes;
                form2.ShowDialog();
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            string reportName;
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Enter heading for report");
                return;
            }
            else
            {
                reportName = textBox3.Text;
            }

            var count = this.reader.TotalRows(1 == 1);
            var selectedPoints = this.codes.Where(x => x.Export == true).ToList();
            if (selectedPoints.Count == 0)
            {
                MessageBox.Show("Select points to export");
                return;
            }
            this.progressBar1.Maximum = count * 2 + 1;
            this.progressBar1.Step = 1;
            this.progressBar1.Value = 0;
            var stations = new List<string>();
            StaticMethods.CreateTmpFolder();
            try
            {
                for (int i = 0; i < count; i++)
                {
                    var text = reader.ReadRow(i, selectedPoints);
                    var station = reader.Station(i);
                    StaticMethods.WriteTmpFiles(text, station);
                    stations.Add(station);
                    this.progressBar1.Value = i + 1;
                    ;
                }
                ;
            }
            catch (Exception a)
            {
                StaticMethods.DeleteTmpFolder();
                MessageBox.Show(a.Message, "Error");
                return;
            }

            if (string.IsNullOrEmpty(outputDirectory))
            {
                var temp = filePath.LastIndexOf("\\");
                var directory = string.Concat(filePath.Take(temp));
                outputDirectory = directory;
            }

            var xWriter = new ExcelWriter(outputDirectory);
            xWriter.CreateWorkbook();
            xWriter.AddColmNames(selectedPoints, 4);
            var progres = this.progressBar1.Value + 1;
            this.progressBar1.Value = progres;
            ;
            for (int i = 0; i < stations.Count; i++)
            {
                var fileName = stations[i];
                xWriter.AddRow(fileName, 6 + i);
                progres++;
                this.progressBar1.Value = progres;
                ;
            }
            int startRow = 6;
            int endRow = 6 + stations.Count - 1;

            int totalColms = selectedPoints.Sum(x => x.CountDataExport()) + 1;
            xWriter.FormatTable(startRow, endRow, 1, totalColms);
            xWriter.FormatStationColm(startRow, endRow, 1);
            xWriter.AddHeading(reportName, totalColms);
            if (checkBox1.Checked)
            {
                xWriter.AddHeader(this.richTextBox1.Lines);
            }

            if (checkBox2.Checked)
            {
                xWriter.AddFooter(reportName);
            }

            xWriter.CreateFile(outputDirectory, "CS", reportName);


            DialogResult res = MessageBox.Show("Report created. Do you want to open report", "Sucsseful", MessageBoxButtons.YesNo);


            if (res == DialogResult.Yes)
            {
                
            System.Diagnostics.Process.Start($"{outputDirectory}\\CS_{reportName}.xls");
               
            }

            StaticMethods.DeleteTmpFolder();
            ;
        }
    }
}
