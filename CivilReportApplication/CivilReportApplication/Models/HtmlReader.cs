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
        private string folderPath;
        private int stationIndex;
        private int designElevation;

        private HtmlDocument document;
        private HtmlDocument innerHtml;
        public HtmlReader(string folderPath)
        {
            this.folderPath = folderPath;
        }

        public int ReadHtml()
        {

            this.document = new HtmlDocument();
            this.document.Load(this.folderPath);
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

            var currentRow = data(allRows[index].InnerHtml);

            if (index == 0)
            {

                stationIndex = Array.IndexOf(currentRow, "Station");
                designElevation = Array.IndexOf(currentRow, "Elevation Design");

                return null;

            }

            var station = double.Parse(currentRow[stationIndex].Replace("+", ""));
            var elevation = double.Parse(currentRow[designElevation].Replace("m", ""));

            return $"{station} {elevation}";
        }

        private string[] data(string html)
        {
            var currentRow = new HtmlDocument();

            currentRow.LoadHtml(html);

            var allColms = currentRow.DocumentNode.SelectNodes("//td");

            string[] result = allColms.Select(x => x.InnerText).ToArray();

            return result;
        }
    }
}
