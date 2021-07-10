namespace CivilReportApplication.DtoExportModels
{
   public class AlignmentReportDto
    {
        public int Id { get; set; }
        
        public string Element { get; set; }
        
        public double StartStation { get; set; }
        
        public double EndStation { get; set; }
        
        public double LengthElement { get; set; }
        
        public double? Radius { get; set; }

        public double? ParameterA { get; set; }

        public double? AngleBeta { get; set; }

        public PointCoordinate Start { get; set; }

        public PointCoordinate End { get; set; }
    }
}
