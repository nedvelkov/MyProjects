using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsConsoleApp.Repository
{
    public class MaterialAtStation
    {
        public string Code { get; set; }
        public double Area { get; set; }
        public double Volume { get; set; }

        public double MiddleLenght(double depth)
        {
            if (this.Area>0)
            {
            return this.Area / depth;

            }
            else
            {

                return 0;
            }
        }
    }
}
