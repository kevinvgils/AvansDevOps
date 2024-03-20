using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Export {
    public class PNGStrategy : IExportStrategy {
        public void Export(string reportContent, string fileName) {
            Console.WriteLine($"Exporting report to PNG: {fileName}");
            Console.WriteLine($"PNG:{reportContent}");
        }
    }
}
