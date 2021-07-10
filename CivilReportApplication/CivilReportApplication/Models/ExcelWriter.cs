namespace CivilReportApplication.Models
{
    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using Microsoft.Office.Interop.Excel;
    using Excel = Microsoft.Office.Interop.Excel;

    using CivilReportApplication.DtoExportModels;
    using CivilReportApplication.DtoImportModels;

    public class ExcelWriter
    {
        private readonly string outputDirectory;
        private int lastRow;
        private int sheetNum;


        //excel objects
        private Excel.Application app;
        private Excel.Workbook workbook;
        private Excel.Worksheet xlWorkSheet;


        private object misValue;

        public ExcelWriter(string outputDirectory)
        {
            this.outputDirectory = outputDirectory;
            this.lastRow = 0;
            this.sheetNum = 1;
        }

        public void CreateWorkbook()
        {
            this.app = new Excel.Application();

            this.misValue = System.Reflection.Missing.Value;

            this.workbook = app.Workbooks.Add(misValue);
            CreateWorksheet();
        }

        public void AddHeading(string heading, int endColm)
        {
            var endHeading = $"{((ColmName)endColm).ToString()}2";
            var range = this.xlWorkSheet.Range["A2", endHeading];
            range.Merge();
            range.HorizontalAlignment = 3;
            range.VerticalAlignment = 3;
            range.Font.Name = "Arial Narrow";
            range.Font.Size = 12;
            range.Font.Bold = true;
            range.Value = heading;

        }

        public void AddColmNames(List<PointFromCrossSection> codes, int row)
        {
            var range = this.xlWorkSheet.Range[$"A{row}", $"A{row + 1}"];
            range.Merge();
            FormatHeading2(range);
            range.Value = "КМ";
            var colmNum = 2;

            foreach (var code in codes)
            {
                var name = code.Name;
                int allColm = code.CountDataExport();
                var endColm = colmNum + allColm - 1;
                var startHeading = $"{((ColmName)colmNum).ToString()}{row}";
                var endHeading = $"{((ColmName)endColm).ToString()}{row}";
                var currentRange = this.xlWorkSheet.Range[startHeading, endHeading];
                currentRange.Merge();
                FormatHeading2(currentRange);
                currentRange.Value = code.Name;
                var list = code.ExportCodes();
                for (int i = 0; i < list.Count; i++)
                {
                    FormatHeading2(row + 1, colmNum);
                    this.xlWorkSheet.Cells[row + 1, colmNum] = list[i];
                    colmNum++;
                }

            }

        }

        private void FormatHeading2(Range range)
        {
            
            range.HorizontalAlignment = 3;
            range.VerticalAlignment = 3;
            range.Font.Name = "Arial Narrow";
            range.Font.Size = 11;
            range.Font.Bold = true;
            range.BorderAround(Excel.XlLineStyle.xlContinuous);
            
        }

        private void FormatHeading2(int row, int colm)
        {
            
            var cell = this.xlWorkSheet.Cells[row, colm];
            cell.HorizontalAlignment = 3;
            cell.VerticalAlignment = 3;
            cell.Font.Name = "Arial Narrow";
            cell.Font.Size = 11;
            cell.Font.Bold = true;
            cell.BorderAround(Excel.XlLineStyle.xlContinuous);
            
        }

        private void FormatStationCell(int row, int colm)
        {
            var cell = this.xlWorkSheet.Cells[row, colm];
            cell.NumberFormat = "0+000.00";
        }
        private void FormatCellTable(int row, int colm)
        {
            
            var cell = this.xlWorkSheet.Cells[row, colm];
            cell.HorizontalAlignment = 3;
            cell.VerticalAlignment = 3;
            cell.Font.Name = "Arial Narrow";
            cell.Font.Size = 10;
            cell.BorderAround(Excel.XlLineStyle.xlContinuous);
            
        }

        public void AddRow(string[] array, int rowNum)
        {

            for (int i = 0; i < array.Length; i++)
            {
                FormatHeading2(rowNum, i + 1);
                xlWorkSheet.Cells[rowNum, i + 1] = array[i];
            }
            if (lastRow < rowNum) lastRow = rowNum;

        }

        public void AddRow(AlignmentReportDto report, int rowNum)
        {
            var allProperties = report.GetType().GetProperties();
            foreach (var property in allProperties)
            {
                int colmNum = (int)Enum.Parse(typeof(ColumsAlignmentExcel), property.Name);
                var value = property.GetValue(report);

                if (value == null) value = "";

                if (value.GetType().ToString() == "System.Double")
                {
                    var wrtiteValue = ((double)value).ToString("f2");
                    xlWorkSheet.Cells[rowNum, colmNum] = wrtiteValue;
                    continue;
                }
                xlWorkSheet.Cells[rowNum, colmNum] = value.ToString();
            }

        }
        public void AddRow(ProfileReportDto report, int rowNum)
        {
            var allProperties = report.GetType().GetProperties();
            foreach (var property in allProperties)
            {
                int colmNum = (int)Enum.Parse(typeof(ColumsProfileExcel), property.Name);
                var value = property.GetValue(report);

                if (value == null) value = "";

                if (value.GetType().ToString() == "System.Double")
                {
                    var wrtiteValue = ((double)value).ToString("f2");

                    xlWorkSheet.Cells[rowNum, colmNum] = wrtiteValue;

                    continue;
                }

                xlWorkSheet.Cells[rowNum, colmNum] = value.ToString();
            }

        }

        public void AddRow(SurfaceProfileReportDto report, int rowNum)
        {
            var allProperties = report.GetType().GetProperties();
            foreach (var property in allProperties)
            {
                int colmNum = (int)Enum.Parse(typeof(ColumsSurfaceProfileExcel), property.Name);
                var value = property.GetValue(report);

                if (value == null) value = "";


                if (value.GetType().ToString() == "System.Double")
                {
                    var wrtiteValue = ((double)value).ToString("f2");

                    xlWorkSheet.Cells[rowNum, colmNum] = wrtiteValue;
                    continue;
                }

                xlWorkSheet.Cells[rowNum, colmNum] = value.ToString();

            }

            var diff = report.Difference;
            if (diff != null)
            {
                var wrtiteValue = ((double)diff).ToString("f0");

                FormatCellTable(rowNum, 6);
                xlWorkSheet.Cells[rowNum, 6] = wrtiteValue;
            }
            else
            {
                FormatCellTable(rowNum, 6);
                xlWorkSheet.Cells[rowNum, 6] = diff.ToString();
            }


        }

        public void AddRow(string fileName, int rowNum)
        {
            var file = StaticMethods.ReadTmpFile(fileName);
            int colm = 1;
            xlWorkSheet.Cells[rowNum, colm] = fileName;

            colm++;
            ;

            foreach (var lines in file)
            {
                foreach (var item in lines)
                {
                    xlWorkSheet.Cells[rowNum, colm] = item;
                    
                    colm++;
                }
            }
        }

        public void FormatTable(int startRow,int endRow,int startColm,int endColm)
        {
            string startRange = $"{((ColmName)startColm).ToString()}{startRow}";
            string endRange = $"{((ColmName)endColm).ToString()}{endRow}";

            var range = xlWorkSheet.Range[startRange, endRange];


            range.HorizontalAlignment = 3;
            range.VerticalAlignment = 3;
            range.Font.Name = "Arial Narrow";
            range.Font.Size = 10;
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.Weight = Excel.XlBorderWeight.xlThin;

            FormatWidthColm(endColm);
        }

        public void FormatStationColm(int startRow,int endRow, int colm)
        {
            var getColm = ((ColmName)colm).ToString();
            var range = xlWorkSheet.Range[$"{getColm}{startRow}", $"{getColm}{endRow}"];
            range.NumberFormat = "0+000.00";
        }

        public void AddHeader(string[] text)
        {
            var sb = new StringBuilder();
            foreach (var item in text)
            {
                sb.AppendLine(item);
            }
            var allText = sb.ToString().TrimEnd();
            this.xlWorkSheet.PageSetup.LeftHeader = allText;
        }

        public void AddFooter(string footer)
        {
            xlWorkSheet.PageSetup.LeftFooter = footer;
        }

        private void FormatWidthColm(int colmNum)
        {
            for (int i = 1; i <= colmNum; i++)
            {
                this.xlWorkSheet.Columns[i].AutoFit();
            }
        }

        public void CreateFile(string outputDirectory, string reportType, string reportName)
        {
            FormatWidthColm(10);

            var fileName = $"{outputDirectory}\\{reportType}_{reportName}.xls";

            workbook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            workbook.Close(true, misValue, misValue);
            app.Quit();

            Dispose();
        }

        private void CreateCellBorder(int row, int colm)
        {
            var borderRange = this.xlWorkSheet.Cells[row, colm].Borders;

            borderRange[XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borderRange[XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            borderRange[XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

        }

        private void CreateWorksheet()
        {

            this.xlWorkSheet = (Excel.Worksheet)workbook.Worksheets.get_Item(sheetNum);
            sheetNum++;
        }

        private void Dispose()
        {
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(app);
        }

    }
}
