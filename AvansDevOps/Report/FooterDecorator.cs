using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Report {
    public class FooterDecorator : ReportDecorator {
        public FooterDecorator(IReport report) : base(report) {
        }

        public override string generate(Sprint.Sprint sprint) {
            return base.generate(sprint) + "\nFooter";
        }
    }
}
