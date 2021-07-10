namespace CivilReportApplication
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml.Linq;

    using CivilReportApplication.Models;
    public partial class LayoutXml : Form
    {
        private string filePath;
        private string outputDirectory;
        private string outputName;
        private string layoutName;
        private StringBuilder sbCivil;

        public LayoutXml()
        {
            InitializeComponent();

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form1 = new MainForm();
            form1.ShowDialog();
        }

        private void btn1_Click(object sender, EventArgs e)
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
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.outputDirectory = folderBrowserDialog.SelectedPath;
            }

            textBox3.Text = outputDirectory;
        }

        private void btn3_Click(object sender, EventArgs e)
        {


            try
            {
                ReadXmlFile(filePath);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid xml file");
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                outputName = layoutName;
            }
            else outputName = textBox2.Text;

            if (string.IsNullOrEmpty(outputDirectory))
            {
                var temp = filePath.LastIndexOf("\\");
                var directory = string.Concat(filePath.Take(temp));
                outputDirectory = directory;
            }

            StaticMethods.WriteTxtFile(outputDirectory, outputName, sbCivil);

        }

        private void ReadXmlFile(string xmlFile)
        {

            var xmlDocument = XDocument.Load(xmlFile);
            var test = xmlDocument
                .Root
                .Elements()
                .Where(x => x.Name.LocalName == "Alignments")
                .Elements()
                .ToList();
            var firstAlignment = test
                .First()
                .Elements()
                .Where(x => x.Name.LocalName == "Profile")
                .ToList();
            var profile = firstAlignment
                .Elements()
                .Where(x => x.Name.LocalName == "ProfAlign")
                .Elements()
                .ToList();
            var profileName = firstAlignment.Elements()
                .Where(x => x.Name.LocalName == "ProfAlign")
                .First()
                .Attributes()
                .First()
                .Value;

            this.layoutName = profileName;

            this.progressBar1.Maximum = profile.Count();
            this.progressBar1.Step = 1;
            this.progressBar1.Value = 0;
            var progres = 1;

            this.sbCivil = new StringBuilder();
            foreach (var item in profile)
            {

                if (item.HasAttributes)
                {
                    sbCivil.AppendLine($"{item.Value} {item.Attributes().First().Value}");
                }
                else
                {
                    sbCivil.AppendLine($"{item.Value}");
                }

                this.progressBar1.Value = progres;
                progres++;
            }
        }

        private void LayoutXml_Load(object sender, EventArgs e)
        {

        }
    }
}
