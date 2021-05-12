using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using CivilReportApplication;


namespace CivilReportApplication.Models
{
    public class HtmlReader
    {
        private readonly string filePath;
        private int stationIndex;
        private int designElevation;

        private HtmlDocument document;
        private HtmlDocument innerHtml;
        public HtmlReader(string filePath)
        {
            this.filePath = filePath;
        }

        public int ReadHtml()
        {

            this.document = new HtmlDocument();
            this.document.Load(this.filePath);
            var nodes = document.DocumentNode.SelectNodes("//tbody").ToList();
            var table = nodes.Skip(1).First();
            this.innerHtml = new HtmlDocument();
            innerHtml.LoadHtml(table.InnerHtml);
            var allRows = innerHtml.DocumentNode.SelectNodes("//tr").ToList();
            return allRows.Count;

        }

        public string LayoutName()
        {
            var fullTitle = document.DocumentNode.SelectNodes("//hr").First().NextSibling.InnerText;
            var startIndex = fullTitle.IndexOf(":");
            var endIndex = fullTitle.IndexOf("\n");
            var title = fullTitle.Substring(startIndex + 2, endIndex - startIndex - 2);

            return title;
        }

        public string ReadRow(int index)
        {
            var allRows = innerHtml.DocumentNode.SelectNodes("//tr").ToList();

            var currentRow = Data(allRows[index].InnerHtml);

            if (index == 0)
            {

                stationIndex = Array.IndexOf(currentRow, "Station");
                designElevation = Array.IndexOf(currentRow, "Elevation Design");

                return null;

            }

            var station = double.Parse(currentRow[stationIndex].Replace("+", ""));

            double.TryParse(currentRow[designElevation].Replace("m", ""), out double elevation);

            return $"{station} {elevation}";
        }

        public string ReadRow(int index,int elevationIndex,int stationIndex=0)
        {
            var allRows = innerHtml.DocumentNode.SelectNodes("//tr").ToList();

            var currentRow = Data(allRows[index].InnerHtml);

            var station = double.Parse(currentRow[stationIndex].Replace("+", ""));

            double.TryParse(currentRow[elevationIndex].Replace("m", ""), out double elevation);

            return $"{station} {elevation}";
        }

        public Dictionary<string,int> PointCodes()
        {
            ReadHtml();
            var allRows = innerHtml.DocumentNode.SelectNodes("//tr").ToList();
            var temp=allRows[0].InnerHtml;
            var currentRow = new HtmlDocument();

            currentRow.LoadHtml(temp);

            var allColms = currentRow.DocumentNode.SelectNodes("//td").Select(x=>x.InnerText).ToArray();
            var result = new Dictionary<string, int>();
            for (int i = 0; i < allColms.Length; i++)
            {
                if (allColms[i] == "&nbsp;") continue;
                result.Add(allColms[i], i);
            }

            return result;

        }

        private string[] Data(string html)
        {
            var currentRow = new HtmlDocument();

            currentRow.LoadHtml(html);

            var allColms = currentRow.DocumentNode.SelectNodes("//td");

            string[] result = allColms.Select(x => x.InnerText).ToArray();

            return result;
        }

        
    }
}
