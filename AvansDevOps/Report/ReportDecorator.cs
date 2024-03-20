using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Report {
    public abstract class ReportDecorator : IReport {
        protected IReport _report;

        public ReportDecorator(IReport report) {
            _report = report;
        }
        public virtual string generate() {
            return _report.generate();
        }
    }
}
