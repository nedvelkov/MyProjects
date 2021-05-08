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
            var stream = new StreamWriter(direkctoryLayout);
            var text = sb.ToString().TrimEnd();
            using (stream)
            {
                stream.Write(text);
            }
        }
    }
}
