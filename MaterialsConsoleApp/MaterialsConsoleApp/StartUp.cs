using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
namespace MaterialsConsoleApp
{
    class StartUp
    {
        static void Main()
        {


            Engine engine = new Engine();
            engine.Run();
            /*
            var document = XDocument.Load("report.xml");
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
                .Select(x=>x.Value);

            var sectionList = alignmentXml
                .Elements()
                .First()
                .Elements()
                .Where(x => x.Name != "MaterialList");

            foreach (var section in sectionList)
            {
                var sectionAtributes = section.Attributes().Where(x => x.Name == "sta").FirstOrDefault().Value;

                var materialAtStation = section
                    .Elements()
                    .Elements()
                    .Select(x => x.Attributes())
                    .ToList();

                // дава ми всички материали в това сечение
                // права си class със станция, както и с лист с материали, който да вкарвам в тази станция
                // 
                
                ;
            }


            ;
           */




        }
    }
}
