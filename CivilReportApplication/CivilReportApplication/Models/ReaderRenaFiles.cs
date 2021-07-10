namespace CivilReportApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ReaderRenaFiles
    {
        public List<string[]> ReadTab8(string filePath)
        {
            List<string[]> result = new List<string[]>();
            using (var reader = new StreamReader(filePath))
            {
                while (reader.EndOfStream == false)
                {
                    var line = reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    result.Add(line);
                }
            }

            return result;
        }

        public List<string[]> ReadTab5(string filePath)
        {
            List<string[]> result = new List<string[]>();
            using (var reader = new StreamReader(filePath))
            {
                int lineNum = 1;
                while (reader.EndOfStream == false)
                {
                    var line = reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (lineNum <= 10)
                    {
                        lineNum++;
                        continue;
                    }
                    lineNum++;
                    if (double.TryParse(line[0], out double num) == false) continue;
                    result.Add(line);
                }
            }

            return result;
        }

        public List<string> RoadPoint(string filePath)
        {
            List<string> points = new List<string>();
            using (var reader = new StreamReader(filePath, Encoding.Default))
            {
                int lineNum = 1;
                while (reader.EndOfStream == false)
                {
                    var line = reader.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (lineNum == 8)
                    {
                        points.Add(line[3].Trim());
                        points.Add(line[4].Trim());
                        points.Add(line[5].Trim());

                        break;
                    }
                    lineNum++;
                }
            }

            return points;
        }
    }
}
