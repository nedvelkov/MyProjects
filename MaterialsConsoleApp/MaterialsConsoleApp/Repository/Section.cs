namespace MaterialsConsoleApp.Repository
{
    using System.Collections.Generic;

    public class Section
    {
        public Section()
        {
            this.Materials = new HashSet<MaterialAtStation>();
        }
        public double Station { get; set; }

        public ICollection<MaterialAtStation> Materials { get; set; }
    }
}
