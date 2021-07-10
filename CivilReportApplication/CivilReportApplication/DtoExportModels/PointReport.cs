namespace CivilReportApplication.DtoExportModels
{
   public class PointReport
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Offset { get; set; }
        public string Slope { get; set; }
        public double Easting { get; set; }
        public double Northing { get; set; }

        public string Side() => this.Offset > 0 ? "Right" : this.Offset < 0 ? "Left" : "Centre line";
    }
}
