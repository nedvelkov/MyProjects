using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using CivilReportApplication;
using CivilReportApplication.DtoExportModels;

namespace CivilReportApplication.Models
{
    public class HtmlReader
    {
        private readonly string filePath;
        private int stationIndex;
        private int designElevation;

        private HtmlDocument document;
        private HtmlDocument innerHtml;
        private List<HtmlNode> allRows;
        public HtmlReader(string filePath)
        {
            this.filePath = filePath;
        }

        public int TotalRows()
        {
            if (IsInitilize())
            {
                ReadHtml();
            }

            return this.allRows.Count;
        }

        private bool IsInitilize()
        {
            var result = false;
            try
            {
                result = this.allRows.Count() != 0;
            }
            catch (Exception)
            {

            }
            return result;
        }

        public void ReadHtml()
        {

            this.document = new HtmlDocument();
            this.document.Load(this.filePath);
            var nodes = document.DocumentNode.SelectNodes("//tbody").ToList();
            var table = nodes.Skip(1).First();
            this.innerHtml = new HtmlDocument();
            innerHtml.LoadHtml(table.InnerHtml);
            this.allRows = innerHtml.DocumentNode.SelectNodes("//tr").ToList();

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

        public string ReadRow(int index, bool surfaceProfile = true)
        {

            var currentRow = Data(allRows[index].InnerHtml);

            var sb = new StringBuilder();
            for (int i = 0; i < currentRow.Length; i++)
            {
                sb.Append(currentRow[i]);
                if (i != currentRow.Length - 1)
                {
                    sb.Append(",");
                }
            }

            return sb.ToString();
        }


        public string ReadRow(int index, int elevationIndex, int stationIndex = 0)
        {
            var allRows = innerHtml.DocumentNode.SelectNodes("//tr").ToList();

            var currentRow = Data(allRows[index].InnerHtml);

            var station = double.Parse(currentRow[stationIndex].Replace("+", ""));

            double.TryParse(currentRow[elevationIndex].Replace("m", ""), out double elevation);

            return $"{station} {elevation}";
        }

        public Dictionary<string, int> PointCodesLayout()
        {
            ReadHtml();
            var allRows = innerHtml.DocumentNode.SelectNodes("//tr").ToList();
            var temp = allRows[0].InnerHtml;
            var currentRow = new HtmlDocument();

            currentRow.LoadHtml(temp);

            var allColms = currentRow.DocumentNode.SelectNodes("//td").Select(x => x.InnerText).ToArray();
            var result = new Dictionary<string, int>();
            for (int i = 0; i < allColms.Length; i++)
            {
                if (allColms[i] == "&nbsp;") continue;
                result.Add(allColms[i], i);
            }

            return result;

        }

        public Dictionary<PointReport, int> PointCodesReport()
        {
            ReadHtml();
            var allRows = innerHtml.DocumentNode.SelectNodes("//tr").ToList();
            var temp = allRows[0].InnerHtml;
            var temp2 = allRows[1].InnerHtml;
            var codeRow = new HtmlDocument();
            codeRow.LoadHtml(temp);
            var offesetRow = new HtmlDocument();
            offesetRow.LoadHtml(temp2);

            var allCodes = codeRow.DocumentNode.SelectNodes("//td").Select(x => x.InnerText).ToList();
            var allOffset = offesetRow.DocumentNode.SelectNodes("//td").Select(x =>x.InnerText).ToList();

            var result = new Dictionary<PointReport, int>();
            for (int i = 1; i < allCodes.Count; i++)
            {
                if (allCodes[i] == "&nbsp;") continue;
                PointReport point = new PointReport();
                point.Code = allCodes[i];
                point.Offset = double.Parse(allOffset[i].Replace("m",""));
                
                result.Add(point, i);

            }

            return result;
           // throw new NotImplementedException();
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
