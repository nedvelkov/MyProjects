using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergePDF_app
{
    public partial class Form1 : Form
    {
        private string folderPath;
        private string outputDirectory;
        private string[] files;
        public Form1()
        {
            InitializeComponent();
        }


        private void Merge_Click(object sender, EventArgs e)
        {
            this.progressBar1.Maximum = files.Length;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            string exportName = textBox1.Text;
            this.progress.Text = $"Progres 0/{this.files.Length}";
            if (string.IsNullOrEmpty(exportName))
            {
                exportName = "combinePdf";
            }
            if (exportName.EndsWith(".pdf"))
            {
                exportName = exportName.Replace(".pdf", "");
            }
            this.outputDirectory = $"{this.outputDirectory}\\{exportName}.pdf";

            string[] fileArray = new string[this.files.Length + 1];
            for (int i = 0; i < files.Length; i++)
            {
                fileArray[i] = files[i];
            }

            string outputPdfPath = this.outputDirectory;

            PdfReader reader = null;
            Document sourceDocument = new Document();
            PdfCopy pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(outputPdfPath, FileMode.Create));
            PdfImportedPage importedPage;

            sourceDocument.Open();

            int progress = 1;

            for (int f = 0; f < fileArray.Length - 1; f++)
            {
                reader = new PdfReader(fileArray[f]);

                int pages = TotalPageCount(fileArray[f]);

                //Add pages in new file  
                for (int i = 1; i <= pages; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }

                progressBar1.Value = progress + f;
                this.progress.Text= $"Progres {progress+f}/{this.files.Length}";

                reader.Close();
            }
            //save the output file  
            sourceDocument.Close();
            //OutputText.Text = $"Combine {files.Length} pdf files.";


        }

        private void button1_Click(object sender, EventArgs e)
        {
           List<string> namesPdf=new List<string>();

            OpenFileDialog openFileDialog = new OpenFileDialog() { Multiselect = true, Filter = "PDF files|*.pdf" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.files = openFileDialog.FileNames;
                foreach (var item in files)
                {
                    var fileName = item.Split('\\');
                    namesPdf.Add(fileName[fileName.Length - 1]);
                    ;
                }

                ;
            }
            input.Text = string.Join(",",namesPdf);

          //  OutputText.Text = $"Load {} pdf files.";
        }

        private void OutputText_Click(object sender, EventArgs e)
        {

        }


        private static string[] PdfNames(string folderPath)
        {
            var files = Directory.GetFiles(folderPath);

            return files;
        }

        private static void MergePDF(string[] files, string exportDirectory)
        {



        }

        private static int TotalPageCount(string file)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(file)))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                return matches.Count;
            }
        }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void input_TextChanged(object sender, EventArgs e)
        {

        }

        private void savePathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.outputDirectory = folderBrowserDialog.SelectedPath;
            }

            output.Text = outputDirectory;
        }

        private void combineNamePdf_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
