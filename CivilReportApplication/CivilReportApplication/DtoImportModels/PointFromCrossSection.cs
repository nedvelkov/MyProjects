using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilReportApplication.DtoImportModels
{
    public class PointFromCrossSection
    {
        public Boolean Export { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Side { get; set; }
        public Boolean Elevation { get; set; }
        public Boolean Offset { get; set; }
        public Boolean Easting { get; set; }
        public Boolean Northing { get; set; }
        public Boolean Slope { get; set; }

        public void SetSide(double offset)
        {
            if (offset < 0)
            {
                this.Side = "Left";
            }
            else if (offset > 0)
            {
                this.Side = "Right";
            }
            else
            {
                this.Side = "Centre line";
            }
        }

        public override bool Equals(object obj)
        {
            PointFromCrossSection p = obj as PointFromCrossSection;

            if (p == null) return false;

            bool result = this.Code == p.Code && this.Side == p.Side;
            ;

            return result;

        }

        public int CountDataExport()
        {
            int count = 0;
            if (this.Elevation) count++;
            if (this.Easting) count++;
            if (this.Northing) count++;
            if (this.Offset) count++;
            if (this.Slope && this.Side != "Centre line") count++;

            return count;
        }

        public List<string> ExportCodes()
        {

            List<string> codes = new List<string>();
            if (this.Northing) codes.Add("Х");
            if (this.Easting) codes.Add("У");
            if (this.Elevation) codes.Add("Кота");
            if (this.Offset) codes.Add("Разстояние");
            if (this.Slope && this.Side != "Centre line") codes.Add("Наклон");

            return codes;
        }
    }
}
