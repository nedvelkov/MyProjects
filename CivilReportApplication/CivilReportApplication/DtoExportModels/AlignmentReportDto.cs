using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Point Start { get; set; }

        public Point End { get; set; }


    }
}
