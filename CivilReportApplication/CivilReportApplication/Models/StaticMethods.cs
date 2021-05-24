using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilReportApplication.Models
{
  public static class StaticMethods
    {
        public static string FileName(string fullName)
        {
            var pathIndex = fullName.LastIndexOf("\\");

            var name = fullName.Substring(pathIndex + 1);

            return name;
        }

        public static void WriteTxtFile(string outputDirectory,string outputName,StringBuilder sb)
        {
            var direkctoryLayout = $"{outputDirectory}\\{outputName}.txt";

            var text = sb.ToString().TrimEnd();
            using (var stream= new StreamWriter(direkctoryLayout))
            {
                stream.Write(text);
            }
        }
        public static void WriteScrFile(string outputDirectory, string outputName, StringBuilder sb)
        {
            var direkctoryLayout = $"{outputDirectory}\\{outputName}.scr";

            var text = sb.ToString();
            using (var stream = new StreamWriter(direkctoryLayout))
            {
                stream.Write(text);
            }
        }

        public static void CreateTmpFolder()
        {
            var directory = Directory.GetCurrentDirectory();
            var disk = Directory.GetDirectoryRoot(directory);

            var tmpFolder = Path.Combine(disk, "temp");
            Directory.CreateDirectory(tmpFolder);
        }

        public static void WriteTmpFiles(string text,string fileName)
        {
            var directory = Directory.GetCurrentDirectory();
            var disk = Directory.GetDirectoryRoot(directory);
            ;
            var tmpFolder = Path.Combine(disk, "temp");
            var filePath = Path.Combine(tmpFolder, $"{fileName}.csp");
            using( var stream=new StreamWriter(filePath))
            {
                stream.Write(text);
            }
        }

        public static void DeleteTmpFolder()
        {
            var directory = Directory.GetCurrentDirectory();
            var disk = Directory.GetDirectoryRoot(directory);

            var tmpFolder = Path.Combine(disk, "temp");
            Directory.Delete(tmpFolder,true);
        }

        public static List<string[]> ReadTmpFile(string fileName)
        {
            var directory = Directory.GetCurrentDirectory();
            var disk = Directory.GetDirectoryRoot(directory);
            ;
            var tmpFolder = Path.Combine(disk, "temp");
            var filePath = Path.Combine(tmpFolder, $"{fileName}.csp");

            List<string[]> result = new List<string[]>();

            using (var reader=new StreamReader(filePath))
            {
                while (reader.EndOfStream==false)
                {
                    var line = reader.ReadLine().Split(',');
                    result.Add(line);
                }
            }
            return result;
        }
    }
}
