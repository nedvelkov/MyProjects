﻿using CivilReportApplication.DtoExportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CivilReportApplication.Models
{
    public class XmlReader
    {
        private string filePath;
        private List<XElement> reportList;
        private double startStation;
        private string units;
        private string reportName;
        private double station;

        public XmlReader(string filePath)
        {
            this.filePath = filePath;
        }

        public int ReadFile(string reportType)
        {
            var xmlDocument = XDocument.Load(this.filePath);

            var allAlignments = xmlDocument
                .Root
                .Elements()
                .Where(x => x.Name.LocalName == "Alignments")
                .Elements()
                .ToList();

            this.units = xmlDocument
               .Root
               .Elements()
               .First()
               .Elements()
               .First()
               .Attribute("angularUnit")
               .Value;

            this.reportName = allAlignments
                .First().Attribute("name").Value;

            this.startStation =double.Parse( allAlignments
                .First().Attribute("staStart").Value);

            this.reportList = allAlignments
                .First()
                .Elements()
                .Where(x => x.Name.LocalName == reportType)
                .First()
                .Elements()
                .ToList();

            return this.reportList.Count;
        }

        public string ReportName(string reportType)
        {
            if (reportType == "Profile")
            {

                this.reportName = this.reportList.Elements()
                    .Where(x => x.Name.LocalName == "ProfAlign")
                    .First()
                    .Attributes()
                    .First()
                    .Value;

            }

            return this.reportName;
        }

        public AlignmentReportDto ReadRow(int index)
        {
            var row = this.reportList[index];
            var element = row.Name.LocalName;
            double radius = default;
            double angleBeta = default;
            double parameterA = default;
            var length = double.Parse(row.Attributes().ToList().First(x => x.Name == "length").Value);
            if (element == "Curve")
            {
                radius = double.Parse(row.Attributes().ToList().First(x => x.Name == "radius").Value);
                var alfa = double.Parse(row.Attributes().ToList().First(x => x.Name == "delta").Value);
                if (this.units == "decimal degrees")
                {
                    angleBeta = (180 - alfa) / 0.9;
                }
                else angleBeta = 200 - alfa;
            }
            if (element == "Spiral")
            {
                double radiusSpiral;
                var startSpiral = row.Attributes().ToList().First(x => x.Name == "radiusStart").Value;
                var endSpiral = row.Attributes().ToList().First(a => a.Name == "radiusEnd").Value;
                double.TryParse(startSpiral, out radiusSpiral);
                double.TryParse(endSpiral, out radiusSpiral);
                parameterA = Math.Sqrt(radiusSpiral * length);
            }
            var exportDto = new AlignmentReportDto
            {
                Id = index + 1,
                Element = element,
                LengthElement = length,
                Radius = radius,
                ParameterA = parameterA,
                AngleBeta = angleBeta,


            };

            if (index==0)
            {
                exportDto.StartStation = startStation;
                exportDto.EndStation = startStation+ length;
                this.station = length;
            }
            else
            {
                exportDto.StartStation = station;
                exportDto.EndStation = station + length;
                station += length;
            }

            var listTemp = row.Elements().ToList();
            foreach (var item in listTemp)
            {
                var itemName = item.Name.LocalName;
                if (itemName == "Start" || itemName == "End")
                {
                    var value = item.Value.Split();
                    var point = new Point
                    {
                        X = double.Parse(value[1]),
                        Y = double.Parse(value[0])
                    };
                    
                    exportDto.GetType().GetProperty(itemName).SetValue(exportDto,point);
                    
                }
                
            }


            return exportDto;
        }
    }
}
