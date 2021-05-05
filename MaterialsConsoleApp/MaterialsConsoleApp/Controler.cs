namespace MaterialsConsoleApp
{
    using MaterialsConsoleApp.ExportTable;
    using MaterialsConsoleApp.IO;
    using MaterialsConsoleApp.Repository;
    using MaterialsConsoleApp.Repository.Enum;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class Controler
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly List<Material> materials;
        private readonly List<Section> sections;
        private XDocument dodument;
        public Controler(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.materials = new List<Material>();
            this.sections = new List<Section>();
        }

        public void ReadReport()
        {
            this.writer.Write("Enter quantity report xml location:");
            var location = reader.ReadLine();
            string fullLoaction;
            if (location.EndsWith(".xml") == false)
            {
                this.writer.Write("Enter report name:");
                var nameReport = reader.ReadLine();
                if (nameReport.EndsWith(".xml"))
                { fullLoaction = string.Concat(location, "\\", nameReport); }
                else
                { fullLoaction = string.Concat(location, "\\", nameReport, ".xml"); }

            }
            else
            { fullLoaction = location; }

            try
            {
             //   this.dodument = XDocument.Load(@"C:\Users\usera\Desktop\Civil_ConsoleApp\MaterialListTest\EarthworkTemp.xml");
                 this.dodument = XDocument.Load(fullLoaction);

            }
            catch (Exception)
            {
                writer.WriteLine("Invaid quantity report");
            }
        }

        public void SetAllMaterials()
        {
            if (this.dodument == null)
            {
                this.ReadReport();
                this.SetAllMaterials();
            }

            var materialList = this.dodument
                .Root
                .Elements()
                .Where(x => x.Name == "Alignment")
                .Elements()
                .First()
                .Elements()
                .First()
                .Elements()
                .Attributes()
                .Where(x => x.Name == "name")
                .Select(x => x.Value);

            foreach (var item in materialList)
            {
                writer.Write($"Слой:{item} да се чете:");
                string name = reader.ReadLine();
                if (name == null)
                {
                    name = item;
                }
                writer.Write($"Дебелина на слой {name} в см:");
                var depthInCentimeters = double.Parse(reader.ReadLine());
                var depth = depthInCentimeters / 100.0;

                writer.Write($"Мерна единица слой {name} (m/m2/m3/t):");
                var measure = Enum.Parse<Measure>(reader.ReadLine());

                var material = new Material
                {
                    Name = name,
                    Code = item,
                    Depth = depth,
                    Measure = measure
                };
                this.materials.Add(material);

            }
        }

        public void GetMaterialsBySection()
        {
            var alignmentSectionMaterials = this.dodument
                                              .Root
                                              .Elements()
                                              .Where(x => x.Name == "Alignment");

            var sectionList = alignmentSectionMaterials
                .Elements()
                .First()
                .Elements()
                .Skip(1);

            foreach (var section in sectionList)
            {
                var station = double.Parse(section
                    .Attributes()
                    .FirstOrDefault(x => x.Name == "sta")
                    .Value);

                var materialAtStation = section
                                            .Elements()
                                            .Elements()
                                            .Select(x => x.Attributes())
                                            .ToList();

                var currentSection = new Section
                {
                    Station = station
                };
                foreach (var material in materialAtStation)
                {
                    var code = material.FirstOrDefault(x => x.Name == "name").Value;
                    var volume = double.Parse(material.FirstOrDefault(x => x.Name == "volume").Value);
                    var area = double.Parse(material.FirstOrDefault(x => x.Name == "area").Value);
                    var materialAtSection = new MaterialAtStation
                    {
                        Code = code,
                        Volume = volume,
                        Area = area
                    };
                    currentSection.Materials.Add(materialAtSection);
                }

                this.sections.Add(currentSection);

            }
            ;
        }

        public void ExportResult()
        {
            ;
            writer.Write("Enter name for export list:");
            var fileName = reader.ReadLine();

            ExcelTable table = new ExcelTable();
            table.CreateMaterialTable(this.materials, this.sections, fileName);

        }
    }
}
/*
 *             var document = XDocument.Load("report.xml");
           // Console.WriteLine(document.Root.Name. ToString());
           /*
            * идеята ми е тук да има питана на конзолата -> избери файл: ....
            * зарежда се файла
            * следва четене му
            * изписва се видовете материали 
            * като се заменят имената им с имена на потребителя, в изходните данни
            * излиза съобобщение че всичко е ОК или има проблем с ????? (оптимално)
            * и питане как да се казва файла (.csv), както има възможност за записване в друга директория.
            
var alignmentXml = document
    .Root
    .Elements()
    .Where(x => x.Name == "Alignment");
;
// материали
var materialList = alignmentXml
    .Elements()
    .First()
    .Elements()
    .First()
    .Elements()
    .Attributes()
    .Where(x => x.Name == "name")
    .Select(x => x.Value);

var sectionList = alignmentXml
    .Elements()
    .First()
    .Elements()
    .Where(x => x.Name != "MaterialList");

foreach (var section in sectionList)
{
    var materialAtStation = section
        .Elements()
        .Elements()
        .Select(x => x.Attributes())
        .ToList();

    // дава ми всички материали в това сечение
    // права си class със станция, както и с лист с материали, който да вкарвам в тази станция
    // 

    ;
}*/