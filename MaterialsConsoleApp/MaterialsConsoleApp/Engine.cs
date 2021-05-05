
namespace MaterialsConsoleApp
{
using MaterialsConsoleApp.IO;
  public  class Engine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private Controler controler;
        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public void Run()
        {
            this.controler = new Controler(reader, writer);
            controler.ReadReport();
            controler.SetAllMaterials();
            controler.GetMaterialsBySection();
            controler.ExportResult();
        }
    }
}
