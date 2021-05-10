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

    public class ExcelWriter
    {
        private string outputDirectory;
        private string headingTable;

        //excel objects
        private Excel.Application app;
        private Excel.Workbook workbook;
        private Excel.Worksheet xlWorkSheet;

        private object misValue;

        public ExcelWriter(string outputDirectory)
        {
            this.outputDirectory = outputDirectory;
        }

        public void CreateWorkbook()
        {
            this.app = new Excel.Application();

            this.misValue = System.Reflection.Missing.Value;

            this.workbook = app.Workbooks.Add(misValue);
            CreateWorksheet();
        }


        public void AddRow(string[] array,int rowNum)
        {

            for (int i = 0; i < array.Length; i++)
            {
                xlWorkSheet.Cells[rowNum, i + 1] = array[i];
            }

        }

        public void AddRow(AlignmentReportDto report,int rowNum)
        {
            var allProperties = report.GetType().GetProperties();
            foreach (var property in allProperties)
            {
                int colmNum =(int) Enum.Parse(typeof(ColumsExcel), property.Name);
                xlWorkSheet.Cells[rowNum, colmNum] = property.GetValue(report);
            }
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
