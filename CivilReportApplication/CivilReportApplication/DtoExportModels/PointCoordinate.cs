namespace CivilReportApplication.DtoExportModels
{
   public class PointCoordinate
    {
        public double X { get; set; }
        
        public double Y { get; set; }

        public override string ToString() => $"({this.X:f4},{this.Y:f4})";
    }
}
