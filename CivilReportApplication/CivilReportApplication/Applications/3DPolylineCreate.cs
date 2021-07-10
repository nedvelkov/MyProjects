namespace CivilReportApplication
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using CivilReportApplication.DtoImportModels;
    using CivilReportApplication.Models;

    public partial class Form1 : Form
    {
        private string filePathTab8;
        private string filePathTab5;
        private string outputDirectory;

        private ReaderRenaFiles reader;
        private List<string[]> tab8;
        private List<string[]> tab5;

        public List<ImportDataTab8> points;
        private List<string> roadPoints;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, Filter = "XY files|*.XY" };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePathTab8 = openFileDialog.FileName;
                this.textBox1.Text = StaticMethods.FileName(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Invalid directory");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = false, Filter = "ini files|*.ini" };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePathTab5 = openFileDialog.FileName;
                this.textBox2.Text = StaticMethods.FileName(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Invalid directory");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.filePathTab8 == null)
            {
                MessageBox.Show("Select .XY file", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.filePathTab5 == null)
            {
                MessageBox.Show("Select .ini file", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            reader = new ReaderRenaFiles();
            tab8 = reader.ReadTab8(filePathTab8);
            tab5 = reader.ReadTab5(filePathTab5);
            using (SelectRange3DPolyline form = new SelectRange3DPolyline(tab8, tab5))
            {
                form.ShowDialog();
                if (form.points.Any())
                {

                    this.points = form.points;
                }

            }

            if (this.points != null)
            {
                roadPoints = reader.RoadPoint(filePathTab5);

                this.checkedListBox1.Items.AddRange(roadPoints.ToArray());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.outputDirectory = folderBrowserDialog.SelectedPath;
            }

            textBox3.Text = outputDirectory;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.filePathTab8 == null)
            {
                MessageBox.Show("Select .XY file", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.filePathTab5 == null)
            {
                MessageBox.Show("Select .ini file", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.points == null)
            {
                MessageBox.Show("Select range", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select road points to script", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(this.outputDirectory))
            {
                MessageBox.Show("Select directory for report", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.progressBar1.Maximum = this.checkedListBox1.CheckedItems.Count * this.points.Count;

            this.progressBar1.Step = 0;
            this.progressBar1.Value = 0;

            foreach (string item in checkedListBox1.Items)
            {
                int colm = roadPoints.IndexOf(item);
                GetPointCoodiranteAndElevation(colm);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("-osnap off");
                sb.Append("3dpoly ");
                foreach (var currPoint in points)
                {
                    sb.AppendLine(currPoint.Point.ToString());
                }
                sb.AppendLine();

                StaticMethods.WriteScrFile(this.outputDirectory, $"{item}_{textBox4.Text}", sb);
            }

            MessageBox.Show("Script files done", "Sucsseful", MessageBoxButtons.OK);

        }


        private void GetPointCoodiranteAndElevation(int colm)
        {
            int progress = this.progressBar1.Value;
            foreach (var point in this.points)
            {
                var station = point.Station;
                var coordinates = tab8.First(x => double.Parse(x[1]) == station);
                var elevations = tab5.First(x => double.Parse(x[1]) == station);
                int offset = 0;
                if (colm == 0) offset = 2;
                if (colm == 2) offset = 4;
                PointFor3DPolyline po = new PointFor3DPolyline()
                {
                    X = double.Parse(coordinates[3 + offset]),
                    Y = double.Parse(coordinates[2 + offset]),
                    Z = double.Parse(elevations[3 + colm])
                };
                point.Point = po;
                progress++;
                this.progressBar1.Value = progress;
            }
        }
    }
}
