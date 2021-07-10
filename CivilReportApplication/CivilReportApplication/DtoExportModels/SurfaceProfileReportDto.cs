namespace CivilReportApplication.DtoExportModels
{
    public class SurfaceProfileReportDto
    {
        public double Station { get; set; }
        public double Northing { get; set; }
        public double Easting { get; set; }
        public double? ElevationSurface { get; set; }
        public double? ElevationProfile { get; set; }
        public string PointName { get; set; }

        public double? Difference
        {
            get
            {
                if (IsValid)
                {
                    return (this.ElevationProfile - this.ElevationSurface) * 100;
                }
                return null;
            }
        }

        private bool IsValid => this.ElevationProfile != null && this.ElevationSurface != null;
    }
}
