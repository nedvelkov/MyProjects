using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsConsoleApp.IO.Models
{
    using System.IO;
    public class FileWriter : IWriter
    {
        private string fileName;
        public FileWriter(string fileName)
        {
            this.fileName = fileName;
        }
        public void Write(string text)
        {
            using(StreamWriter writer=new StreamWriter(fileName))
            {
                writer.Write(text);
            }
        }

        public void WriteLine(string text)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(text);
            }
        }
    }
}
