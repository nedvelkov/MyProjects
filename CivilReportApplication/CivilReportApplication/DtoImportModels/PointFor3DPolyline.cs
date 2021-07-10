namespace CivilReportApplication.DtoImportModels
{
    public class PointFor3DPolyline
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public override string ToString() => $"{this.X},{this.Y},{this.Z}";
    }
}
