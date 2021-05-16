using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Side()
        {
            if (this.Offset>0)
            {
                return "Right";
            }else if (this.Offset < 0)
            {
                return "Left";
            }
            else
            {
                return "Centre line";
            }
        }
    }
}
