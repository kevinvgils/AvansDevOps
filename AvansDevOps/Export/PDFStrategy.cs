using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Export {
    public class PdfStrategy : IExportStrategy {
        public void Export(string reportContent, string fileName) {
            Console.WriteLine($"Exporting report to PDF: {fileName}");
            Console.WriteLine($"PDF:{reportContent}");

        }
    }
}
