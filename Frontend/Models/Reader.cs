using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class Reader
    {
        public string[] ReadFile(string filename)
        {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, filename);
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines;
        }
    }
}
