using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Report {
    public class BaseReport : IReport {
        public string generate() {
            return "This is a basic report";
        }

        public void save() { throw new NotImplementedException(); }
    }
}
