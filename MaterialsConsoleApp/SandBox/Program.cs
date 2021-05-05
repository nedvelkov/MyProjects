using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {

           Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
           // Excel.ApplicationClass app = new Excel.ApplicationClass();


            if (xlApp == null)
            {
                Console.WriteLine("Excel is not properly installed!!");
                return;
            }

            object misValue = System.Reflection.Missing.Value;

            var xlWorkBook = xlApp.Workbooks.Add(misValue);

            var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //xlWorkSheet.Cells[1, 1] = "ID";
            //xlWorkSheet.Cells[1, 2] = "Name";
            //xlWorkSheet.Cells[2, 1] = "1";
            //xlWorkSheet.Cells[2, 2] = "One";
            //xlWorkSheet.Cells[3, 1] = "2";
            //xlWorkSheet.Cells[3, 2] = "Two";


            var kmHeading = xlWorkSheet.Range["A4", "A5"];
            kmHeading.Value = "км";
            kmHeading.Merge();

            var materialOneHeading = xlWorkSheet.Range["B4", "D4"];
            materialOneHeading.Value = "плътен";
            materialOneHeading.Merge();



            xlWorkBook.SaveAs($"C:\\Users\\usera\\Desktop\\Civil_ConsoleApp\\MaterialListTest\\try.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

        }
    }
}
