using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CivilReportApplication.Models
{


    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;

    using CivilReportApplication.DtoExportModels;
    using Microsoft.Office.Interop.Excel;

    public class ExcelWriter
    {
        private string outputDirectory;
        private string headingTable;
        private int lastRow;

        //excel objects
        private Excel.Application app;
        private Excel.Workbook workbook;
        private Excel.Worksheet xlWorkSheet;

        private Excel.Style styleHeading1;
        private Excel.Style styleHeading2;
        private Excel.Style styleCellNormal;


        private object misValue;

        public ExcelWriter(string outputDirectory)
        {
            this.outputDirectory = outputDirectory;
            this.lastRow = 0;
        }

        public void CreateWorkbook()
        {
            this.app = new Excel.Application();

            this.misValue = System.Reflection.Missing.Value;

            this.workbook = app.Workbooks.Add(misValue);
            CreateWorksheet();
        }

        private void CreateStyles()
        {
            this.styleHeading1 = this.workbook.Styles.Add("HeadingStyle1");
            styleHeading1.Font.Size = 12;


            //Style myStyle = workbook.Styles.Add("My Style");

            //// Specify the style's format characteristics.
            //    // Set the font color to blue.
            //    myStyle.Font.Color = Color.Blue;

            //    // Set the font size to 12.
            //    myStyle.Font.Size = 12;

            //    // Center text in cells.
            //    myStyle.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

            //    // Set the background fill.
            //    myStyle.Fill.BackgroundColor = Color.LightBlue;
            //    myStyle.Fill.PatternType = PatternType.LightGray;
            //    myStyle.Fill.PatternColor = Color.Yellow;

        }

        public void AddHeading(string heading)
        {

            var range = this.xlWorkSheet.Range["A2", "J2"];
            range.Merge();
            range.HorizontalAlignment = 3;//Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = 3;// Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.Font.Name = "Arial Narrow";
            range.Font.Size = 12;
            range.Font.Bold = true;
            range.Value = heading;

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
        private void FormatCellTable(int row, int colm)
        {
            var cell = this.xlWorkSheet.Cells[row, colm];
            cell.HorizontalAlignment = 3;
            cell.VerticalAlignment = 3;
            cell.Font.Name = "Arial Narrow";
            cell.Font.Size = 10;
            cell.BorderAround(Excel.XlLineStyle.xlContinuous); 
            //BorderAround(Excel.XlLineStyle.xlContinuous,
            //Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic,
            //Excel.XlColorIndex.xlColorIndexAutomatic);
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
                int colmNum = (int)Enum.Parse(typeof(ColumsExcel), property.Name);
                var value = property.GetValue(report);

                if (value == null) value = "";

                //var type = value.GetType().ToString();

                if (value.GetType().ToString() == "System.Double")
                {
                    var wrtiteValue = ((double)value).ToString("f2");
                    FormatCellTable(rowNum, colmNum);
                    xlWorkSheet.Cells[rowNum, colmNum] = wrtiteValue;
                    //CreateCellBorder(rowNum, colmNum);
                    continue;
                }
                FormatCellTable(rowNum, colmNum);
                xlWorkSheet.Cells[rowNum, colmNum] = value.ToString();
                // CreateCellBorder(rowNum, colmNum);
            }


        }

        public void AddHeader(string[] text)
        {
            var sb = new StringBuilder();
            foreach (var item in text)
            {
                sb.AppendLine(item);
            }
            var allText = sb.ToString().TrimEnd();
            this.xlWorkSheet.PageSetup.LeftHeader=allText;
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


        public void CreateFile(string outputDirectory,string reportType ,string reportName)
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
            borderRange[XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

        }

        private void CreateWorksheet()
        {

            this.xlWorkSheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
        }



        private void Dispose()
        {
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(app);
        }
    }

}
