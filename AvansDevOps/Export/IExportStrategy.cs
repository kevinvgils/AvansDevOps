using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Export {
    public interface IExportStrategy {
        void Export(string reportContent, string fileName);
    }
}
