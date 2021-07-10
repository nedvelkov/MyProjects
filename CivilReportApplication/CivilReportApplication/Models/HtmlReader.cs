namespace CivilReportApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using HtmlAgilityPack;

    using CivilReportApplication.DtoImportModels;

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
        public int TotalRows(bool crossSection = true)
        {
            if (IsInitilize())
            {
                this.document = new HtmlDocument();
                this.document.Load(this.filePath);
            }
            var nodes = document.DocumentNode
                                .SelectNodes("//tbody")
                                .Skip(1)
                                .ToList();
            return nodes.Count;
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

            var nodes = document.DocumentNode
                                .SelectNodes("//tbody")
                                .ToList();

            var table = nodes.Skip(1).First();

            this.innerHtml = new HtmlDocument();

            innerHtml.LoadHtml(table.InnerHtml);

            this.allRows = innerHtml.DocumentNode
                                    .SelectNodes("//tr")
                                    .ToList();

        }

        public string LayoutName()
        {
            var fullTitle = document.DocumentNode
                                    .SelectNodes("//hr")
                                    .First()
                                    .NextSibling
                                    .InnerText;
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

            var station = double.Parse(PurgeValue("+", currentRow[stationIndex]));

            double.TryParse(PurgeValue("m", currentRow[designElevation]), out double elevation);

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

            var station = double.Parse(PurgeValue("+", currentRow[stationIndex]));

            double.TryParse(PurgeValue("m", currentRow[elevationIndex]), out double elevation);

            return $"{station} {elevation}";
        }

        public string ReadRow(int index, List<PointFromCrossSection> codes)
        {
            var nodes = document.DocumentNode.SelectNodes("//tbody").Skip(1).ToList();

            var station = nodes[index];
            var currentTable = new HtmlDocument();
            currentTable.LoadHtml(station.InnerHtml);
            ;
            var rows = currentTable.DocumentNode.SelectNodes("//tr").ToList();
            var allCodes = Data(rows[0].InnerHtml);
            int countCodes = allCodes.Length;
            var offsets = Data(rows[1].InnerHtml);
            var elevations = Data(rows[2].InnerHtml);
            var slopes = Data(rows[3].InnerHtml);
            var allEasting = Data(rows[4].InnerHtml);
            var allNorthing = Data(rows[5].InnerHtml);

            var sb = new StringBuilder();

            int indexCode = 0;

            for (int i = 0; i < countCodes; i++)
            {
                var code = allCodes[i];
                var offsetAsString = offsets[i];
                double offset;
               if( double.TryParse(PurgeValue("m",offsetAsString), out offset) == false)
                {
                    continue;
                }
                var point = new PointFromCrossSection();
                point.Code = code;
                point.SetSide(offset);
                var tmp = codes.FirstOrDefault(a => a.Equals(point) == true);

                if (tmp == null)
                {
                    continue;
                }
                var tmpIndex = codes.IndexOf(tmp);
                if (tmpIndex == indexCode)
                {
                    indexCode++;
                    Queue<string> dataPoint = new Queue<string>();

                    if (tmp.Northing)
                    {
                        var nort = double.Parse(PurgeValue(",", allNorthing[i]));
                        dataPoint.Enqueue(nort.ToString("f4"));
                    }
                    if (tmp.Easting)
                    {
                        var east = double.Parse(PurgeValue(",", allEasting[i]));
                        dataPoint.Enqueue(east.ToString("f4"));
                    }
                    if (tmp.Elevation)
                    {
                        var eleavtion = double.Parse(PurgeValue("m", elevations[i]));
                        dataPoint.Enqueue(eleavtion.ToString("f3"));
                    }
                    if (tmp.Offset)
                    {
                        dataPoint.Enqueue(offset.ToString("f3"));
                    }
                    if(tmp.Slope && tmp.Side!= "Centre line")
                    {
                        dataPoint.Enqueue(slopes[i]);
                    }
                    sb.AppendLine(string.Join(",", dataPoint));
                }
                else
                {
                    var codeAtIndex = codes[indexCode];
                    var nullValues = codeAtIndex.CountDataExport();
                    Queue<string> dataPoint = new Queue<string>();
                    for (int d = 0; d < nullValues; d++)
                    {
                        dataPoint.Enqueue(" ");
                    }
                    sb.AppendLine(string.Join(",", dataPoint));
                    indexCode++;
                    i--;
                }
                
            }
            return sb.ToString().TrimEnd();
        }

        public string Station(int index)
        {
            var nodesCentre = document.DocumentNode
                                    .SelectNodes("//center")
                                    .ToList()
                                    .Where((c, i) => i % 2 != 0)
                                    .Select(x => x.InnerText)
                                    .ToList();
            var totalStation = nodesCentre[index];
            var station = totalStation.Split(' ');

            return station[1].Replace("+","").TrimEnd();
        }
        public Dictionary<string, int> PointCodesLayout()
        {
            ReadHtml();
            var allRows = innerHtml.DocumentNode
                                    .SelectNodes("//tr")
                                    .ToList();
            
            var temp = allRows[0].InnerHtml;
            var currentRow = new HtmlDocument();

            currentRow.LoadHtml(temp);

            var allColms = currentRow.DocumentNode
                                     .SelectNodes("//td")
                                     .Select(x => x.InnerText)
                                     .ToArray();

            var result = new Dictionary<string, int>();
            
            for (int i = 0; i < allColms.Length; i++)
            {
                if (allColms[i] == "&nbsp;") continue;
                result.Add(allColms[i], i);
            }

            return result;

        }

        public List<PointFromCrossSection> PointCodesReport()
        {
            ReadHtml();

            var allRows = innerHtml.DocumentNode
                                    .SelectNodes("//tr")
                                    .ToList();

            var temp = allRows[0].InnerHtml;

            var temp2 = allRows[1].InnerHtml;

            var codeRow = new HtmlDocument();

            codeRow.LoadHtml(temp);

            var offesetRow = new HtmlDocument();

            offesetRow.LoadHtml(temp2);

            var allCodes = codeRow.DocumentNode
                                  .SelectNodes("//td")
                                  .Select(x => x.InnerText)
                                  .ToList();

            var allOffset = offesetRow.DocumentNode
                                      .SelectNodes("//td")
                                      .Select(x => x.InnerText)
                                      .ToList();

            var result = new List<PointFromCrossSection>();
            for (int i = 1; i < allCodes.Count; i++)
            {
                if (allCodes[i] == "&nbsp;")
                {
                    continue;
                }

                PointFromCrossSection point = new PointFromCrossSection();
                point.Code = allCodes[i];

                var offset = double.Parse(PurgeValue("m", allOffset[i]));


                point.SetSide(offset);

                result.Add(point);

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

        private string PurgeValue(string purgeChar, string value)
            => value = value.Replace(purgeChar, "");
    }
}
