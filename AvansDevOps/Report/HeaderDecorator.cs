using AvansDevOps.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Report {
    public class HeaderDecorator : ReportDecorator {
        public HeaderDecorator(IReport report) : base(report) {
        }

        public override string generate() {
            return "Header\n" + base.generate();
        }
    }
}
