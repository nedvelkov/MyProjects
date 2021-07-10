namespace CivilReportApplication.DtoImportModels
{

    using System;
    using System.Collections.Generic;

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

        public void SetSide(double offset) => this.Side = offset < 0 ? "Left" : offset > 0 ? "Right" : "Centre line";

        public override bool Equals(object obj)
        {
            PointFromCrossSection p = obj as PointFromCrossSection;

            if (p == null) return false;

            return this.Code == p.Code && this.Side == p.Side;

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
