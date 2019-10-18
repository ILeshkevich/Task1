using System;
using System.Collections.Generic;
using System.Linq;

namespace MostModifiedFiles.Utilities
{
    public class Printer
    {
        private readonly Dictionary<string, int> files;
        public Printer(Dictionary<string, int> files)
        {
            this.files = files;
        }

        public void PrintMostModifiedFiles()
        {
            foreach (var file in files.OrderByDescending(f=>f.Value).ThenBy(f=>f.Key).Take(10))
            {
                var i = 1;
                Console.WriteLine($"{i++}: {file.Key} -- {file.Value}");
            }
        }
    }
}