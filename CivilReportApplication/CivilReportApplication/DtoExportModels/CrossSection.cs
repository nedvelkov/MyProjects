using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilReportApplication.DtoExportModels
{
    public class CrossSection
    {
        private readonly List<PointReport> points;
        public CrossSection()
        {
            this.points = new List<PointReport>();
        }
        public double Station { get; set; }
        public List<PointReport> Points => this.points.OrderBy(x => x.Offset).ToList();

        public void AddPont(PointReport point)
        {
            this.points.Add(point);
        }
    }
}
