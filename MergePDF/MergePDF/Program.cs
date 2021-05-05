using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MergePDF
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Enter folder location:");
            string folderPath = Console.ReadLine();

            var files = PdfNames(folderPath);

            Console.Write("Enter export file location:");
            string exportPath = Console.ReadLine();
            Console.Write("Enter export file name:");
            string exportName = Console.ReadLine();

            string exportDirectory = $"{exportPath}\\{exportName}.pdf";

            MergePDF(files, exportDirectory);

        }


        private static string[] PdfNames(string folderPath)
        {
            var files = Directory.GetFiles(folderPath);

            var result = new string[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                result[i] = files[i].Substring(folderPath.Length);
            }

            return files;
        }

        private static void MergePDF(string[] files, string exportDirectory)
        {
            string[] fileArray = new string[files.Length + 1];
            for (int i = 0; i < files.Length; i++)
            {
                fileArray[i] = files[i];
            }

            string outputPdfPath = exportDirectory;

            PdfReader reader = null;
            Document sourceDocument = new Document();
            PdfCopy pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(outputPdfPath, FileMode.Create));
            PdfImportedPage importedPage;

            sourceDocument.Open();

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
                 
                reader.Close();
            }
            //save the output file  
            sourceDocument.Close();

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

    }
}
/* private static void MergePDF(string File1,string File2)  
       {  
           string[] fileArray = new string[3];  
           fileArray[0] = File1;  
           fileArray[1] = File2;  
  
           PdfReader reader = null;  
           Document sourceDocument = null;  
           PdfCopy pdfCopyProvider = null;  
           PdfImportedPage importedPage;  
           string outputPdfPath = @"E:/newFile.pdf";  
  
           sourceDocument = new Document();  
           pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));  
  
           //output file Open  
           sourceDocument.Open();  
  
  
           //files list wise Loop  
           for (int f = 0; f < fileArray.Length - 1; f++)  
           {  
               int pages = TotalPageCount(fileArray[f]);  
  
               reader = new PdfReader(fileArray[f]);  
               //Add pages in new file  
               for (int i = 1; i <= pages; i++)  
               {  
                   importedPage = pdfCopyProvider.GetImportedPage(reader, i);  
                   pdfCopyProvider.AddPage(importedPage);  
               }  
  
               reader.Close();  
           }  
           //save the output file  
           sourceDocument.Close();  
       }  
  
       private static int TotalPageCount(string file)  
       {  
           using (StreamReader sr = new StreamReader(System.IO.File.OpenRead(file)))  
           {  
              // Regex regex = new Regex(@"/Type\s*-/Page[^s]");  
               MatchCollection matches = regex.Matches(sr.ReadToEnd());

return matches.Count;  
           }  
       }
*/