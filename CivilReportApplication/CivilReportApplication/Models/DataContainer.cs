namespace CivilReportApplication
{

    using System;
    using System.Collections.Generic;

    public class DataContainer
    {
        public string[] Report { get; set; }

        public bool IsValid()
        {
            bool result = false;
            try
            {
                result = this.Report.Length != 0;
            }
            catch (Exception)
            {

            }


            return result;
        }
    }
}
