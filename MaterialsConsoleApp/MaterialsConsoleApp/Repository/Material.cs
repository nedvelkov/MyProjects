namespace MaterialsConsoleApp.Repository
{

using MaterialsConsoleApp.Repository.Enum;

   public class Material
    {

        public string Name { get; set; }

        public string Code { get; set; }

        public double Depth { get; set; }

        public Measure Measure { get; set; }
    }
}
