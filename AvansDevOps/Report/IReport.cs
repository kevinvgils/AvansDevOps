using AvansDevOps.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Report {
    public interface IReport {
        public string generate();
        public void Export(IExportStrategy exportStrategy, string fileName);
    }
}
