﻿namespace MaterialsConsoleApp.IO
{

using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
