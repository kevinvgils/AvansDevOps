using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Report {
    public class HeaderDecorator : ReportDecorator {
        public HeaderDecorator(Report report) : base(report) {
        }

        public override string generate() {
            return $"HeaderDecorator({base.generate()})";
        }
    }
}
