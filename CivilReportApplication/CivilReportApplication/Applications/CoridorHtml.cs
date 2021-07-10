namespace CivilReportApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using CivilReportApplication.Models;

    public partial class CoridorHtml : Form
    {
        private string filePath;
        private string outputDirectory;
        private HtmlReader reader;
        private Dictionary<string, int> codes;

        public CoridorHtml()
        {
            InitializeComponent();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
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
            this.codes = reader.PointCodesLayout();

            foreach (var code in codes)
            {
                this.chkListBox1.Items.Add(code.Key);
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

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form1 = new MainForm();
            form1.ShowDialog();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {

            var points = this.chkListBox1.CheckedItems;
            if (points.Count == 0)
            {
                MessageBox.Show("Chose point/points");
                return;
            }
            reader.ReadHtml();
            var allRows = reader.TotalRows();
            this.progressBar1.Maximum = (allRows - 2) * points.Count;
            this.progressBar1.Step = 1;
            int progress = 0;
            this.progressBar1.Value = progress;
            foreach (string code in points)
            {
                var sb = new StringBuilder();
                var elevationIndex = this.codes[code] * 3;
                for (int i = 2; i < allRows; i++)
                {
                    sb.AppendLine(this.reader.ReadRow(i, elevationIndex));
                    progress++;
                    this.progressBar1.Value = progress;
                }

                if (string.IsNullOrEmpty(outputDirectory))
                {
                    var temp = filePath.LastIndexOf("\\");
                    var directory = string.Concat(filePath.Take(temp));
                    outputDirectory = directory;
                }

                StaticMethods.WriteTxtFile(outputDirectory, code + "_niv", sb);
            }

        }
    }
}
