using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilReportApplication.DtoImportModels
{
    public class PointFor3DPolyline
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public override string ToString()
        {
            return $"{this.X},{this.Y},{this.Z}";
        }
    }
}
