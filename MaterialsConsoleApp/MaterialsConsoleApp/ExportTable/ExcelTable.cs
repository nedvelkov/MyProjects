namespace MaterialsConsoleApp.ExportTable
{

    using System.Collections.Generic;
    using System.Linq;

    using Excel = Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    using MaterialsConsoleApp.Repository;

    public class ExcelTable
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        public ExcelTable()
        {
            this.xlApp = new Microsoft.Office.Interop.Excel.Application();
        }

        private void CreateWoorkbook()
        {
            object misValue = System.Reflection.Missing.Value;

            this.xlWorkBook = xlApp.Workbooks.Add(misValue);
        }

        private void CreateSheet()
        {
            this.xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        }

        public void CreateMaterialTable(List<Material> materials, List<Section> sections, string fileName)
        {
            this.CreateWoorkbook();
            this.CreateSheet();
            int sectionIndex = 0;
            var allVolumeCalculation = new List<CalculateVolume>();
            foreach (var material in materials)
            {
                var calculateTable = new CalculateVolume(material.Code);
                calculateTable.LinkedList.AddFirst(0);
                allVolumeCalculation.Add(calculateTable);
            }
            for (int row = 4; row < 99999; row++)
            {
                if (row == 4)
                {
                    // station
                    var colm = 1;
                    AddColumnName("km", colm, row, row + 1);
                    colm++;
                    for (int i = 0; i < materials.Count; i++)
                    {
                        var material = materials[i];
                        AddColumnNameForMaterials(material.Name, colm, colm + 2, row);
                        colm += 3;
                    }
                    continue;
                }
                if (row == 5)
                {
                    var colm = 2;
                    var i = 0;
                    while (true)
                    {
                        var material = materials[i];
                        if (material.Measure.ToString() == "m2")
                        {
                            AddValueToCell("ср.широчина", row, colm);
                            colm++;
                            AddValueToCell("площ", row, colm);
                            colm++;
                            AddValueToCell("сума площ", row, colm);
                            colm++;

                        }
                        else
                        {
                            AddValueToCell("ср.широчина", row, colm);
                            colm++;
                            AddValueToCell("обем", row, colm);
                            colm++;
                            AddValueToCell("сума обем", row, colm);
                            colm++;

                        }
                        i++;

                        if (i >= materials.Count)
                        {
                            break;
                        }

                    }
                    continue;
                }

                var currentSection = sections[sectionIndex];
                var colmun = 1;
                // station
                AddValueToCell(currentSection.Station, row, colmun);
                colmun++;
                //materials
                foreach (var mat in currentSection.Materials)
                {
                    var depth = materials.Where(x => x.Code == mat.Code).Select(x => x.Depth).FirstOrDefault();
                    AddValueToCell(mat.Area / depth, row, colmun);
                    colmun += 1;
                    AddValueToCell(mat.Volume / depth, row, colmun);
                    colmun += 1;

                    if (row == 6)
                    {
                        AddValueToCell(0, row, colmun);
                        var currentCalculate = allVolumeCalculation.Where(x => x.MaterialName == mat.Code).FirstOrDefault();
                    }
                    else
                    {
                        var currentCalculate = allVolumeCalculation.Where(x => x.MaterialName == mat.Code).First();
                        var volume = currentCalculate.LinkedList.GetLast() + mat.Volume / depth;
                        currentCalculate.LinkedList.AddLast(volume);
                        AddValueToCell(volume, row, colmun);
                    }

                    colmun += 1;
                }
                sectionIndex++;
                if (sectionIndex >= sections.Count) break;

            }

            this.SaveDocumment(fileName);



        }


        private void AddColumnName(string name, int colm, int startRow, int endRow)
        {
            var startRange = $"{(ColmName)colm}{startRow}";
            var endRange = $"{(ColmName)colm}{endRow}";

            var range = xlWorkSheet.Range[startRange, endRange];
            range.Value = name;
            range.Merge();
        }

        private void AddColumnNameForMaterials(string name, int startColm, int endColm, int row)
        {
            var startRange = $"{(ColmName)startColm}{row}";
            var endRange = $"{(ColmName)endColm}{row}";

            var range = xlWorkSheet.Range[startRange, endRange];
            range.Value = name;
            range.Merge();
        }

        private void AddValueToCell(string value, int row, int colm)
        {
            xlWorkSheet.Cells[row, colm] = value;

        }

        private void AddValueToCell(double value, int row, int colm)
        {
            xlWorkSheet.Cells[row, colm] = value;

        }


        private void AddHeading(string heading, int end)
        {
            var endRange = $"{(ColmName)end}2";
            var range = this.xlWorkSheet.Range["A2", endRange];
            range.Value = heading;
            range.Merge();
        }

        private void SaveDocumment(string fileName)
        {
            object misValue = System.Reflection.Missing.Value;


            xlWorkBook.SaveAs($"C:\\Users\\usera\\Desktop\\Civil_ConsoleApp\\MaterialListTest\\{fileName}.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }


    }
}
/*
 *   if (xlApp == null)
            {
                writer.WriteLine("Excel is not properly installed!!");
                return;
            }


            var kmHeading = xlWorkSheet.Range["A4", "A5"];
            kmHeading.Value = "км";
            kmHeading.Merge();

            var materialOneHeading = xlWorkSheet.Range["B4", "D4"];
            materialOneHeading.Value = "плътен";
            materialOneHeading.Merge();



            xlWorkBook.SaveAs($"C:\\Users\\usera\\Desktop\\Civil_ConsoleApp\\MaterialListTest\\{fileName}.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
*/