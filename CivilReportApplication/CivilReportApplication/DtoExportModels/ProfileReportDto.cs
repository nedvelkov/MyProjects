namespace CivilReportApplication.DtoExportModels
{
    public class ProfileReportDto
    {
        public int Id { get; set; }
        public double Station { get; set; }
        public double Elevation { get; set; }
        public string Slope { get; set; }
        public double? Radius { get; set; }
        public double? Lenght { get; set; }
    }
}
