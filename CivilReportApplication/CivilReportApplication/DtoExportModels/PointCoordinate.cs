using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilReportApplication.DtoExportModels
{
   public class PointCoordinate
    {
        public double X { get; set; }
        
        public double Y { get; set; }

        public override string ToString()
        {
            return $"({this.X:f4},{this.Y:f4})";
        }
    }
}
