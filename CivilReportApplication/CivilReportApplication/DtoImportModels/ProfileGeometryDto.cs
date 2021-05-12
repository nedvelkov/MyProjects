using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilReportApplication.DtoImportModels
{
    public class ProfileGeometryDto
    {
        public string No { get; set; }
        public string PVI_Station { get; set; }
        public string PVI_Elevation { get; set; }
        public string Grade_In { get; set; }
        public string Grade_Out { get; set; }
        public string Grade_Change { get; set; }
        public string Profile_Curve_Type { get; set; }
        public string Sub_Entity_Type { get; set; }
        public string Profile_Curve_Length { get; set; }
        public string K_Value { get; set; }
        public string Curve_Radius { get; set; }
        public string Asymmetric_Length_1 { get; set; }
        public string Asymmetric_Length_2 { get; set; }
        public string Lock { get; set; }

    }
}
