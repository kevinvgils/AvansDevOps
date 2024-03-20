using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Report {
    public class BaseReport : Report {
        public override string generate() {
            return "Base Report";
        }

        public void save() { throw new NotImplementedException(); }
    }
}
