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
    public partial class ProfleReport : Form
    {
        public ProfleReport()
        {
            InitializeComponent();
            this.ProfileGeometry = new List<ProfileGeometryDto>();
        }

        public List<ProfileGeometryDto> ProfileGeometry { get; set; }
        private string outputDirectory;

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form1 = new MainForm();
            form1.ShowDialog();
        }


        private void ReadBtn_Click(object sender, EventArgs e)
        {
            List<ProfileReportDto> profileReport = new List<ProfileReportDto>();

            int allColms = 0;
            try
            {
                allColms = this.dataGridView1.Rows.Count - 1;
                if (allColms == 0)
                {
                    throw new Exception();
                }

                this.progressBar1.Maximum = allColms * 2 + 1;
                this.progressBar1.Step = 1;
                this.progressBar1.Value = 0;

                for (int i = 0; i < allColms; i++)
                {

                    var id = dataGridView1[0, i].Value.ToString();
                    var station = dataGridView1[1, i].Value.ToString();
                    var elevation = dataGridView1[2, i].Value.ToString();
                    var slope = dataGridView1[4, i].Value.ToString();
                    var currentRadius = dataGridView1[10, i].Value.ToString();
                    var currentLenght = dataGridView1[8, i].Value.ToString();
                    var infoRow = new ProfileReportDto()
                    {
                        Id = int.Parse(id),
                        Station = double.Parse(station.Replace("m", "").Replace("+", "")),
                        Elevation = double.Parse(elevation.Replace("m", "")),
                        Slope = slope
                    };
                    if (string.IsNullOrEmpty(currentRadius)==false)
                    {
                    double.TryParse(currentRadius.Replace("m", ""), out double radius);
                    double.TryParse(currentLenght.Replace("m", ""), out double lenght);

                    infoRow.Radius = radius;
                    infoRow.Lenght = lenght;

                    }

                    profileReport.Add(infoRow);
                    this.progressBar1.Value = i + 1;
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Enter valid profile geometry");
                return;
            }

            if (string.IsNullOrEmpty(this.outputDirectory))
            {
                MessageBox.Show("Select directory for report");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Enter alignment name");
                return;
            }
            var writer = new ExcelWriter(this.outputDirectory);
            writer.CreateWorkbook();
            var headingsColum = new string[] { "No", "КМ", "Кота", "Наклон", "Радиус", "Дължина на крива" };
            var progress = this.progressBar1.Value;
            progress++;
            this.progressBar1.Value = progress;
            writer.AddRow(headingsColum, 4);
            for (int i = 0; i < profileReport.Count; i++)
            {
                var currentRow = profileReport[i];
                //TODO : Clear 0.00 at radius and curve lenght
                writer.AddRow(currentRow, 5 + i);

                this.progressBar1.Value = progress + 1 + i;
            }
            writer.AddHeading($"Данни за нивелетата за {textBox2.Text}", 6);
            if (checkBox1.Checked)
            {
                writer.AddHeader(this.richTextBox1.Lines);
            }

            if (checkBox2.Checked)
            {
                writer.AddFooter(textBox2.Text);
            }
            writer.CreateFile(outputDirectory, "niv", textBox2.Text);
            ;


            ;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in this.ProfileGeometry)
            {

                profileGeometryDtoBindingSource.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.outputDirectory = folderBrowserDialog.SelectedPath;
            }

            textBox1.Text = outputDirectory;
        }
    }
}
