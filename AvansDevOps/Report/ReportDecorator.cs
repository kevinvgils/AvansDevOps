using AvansDevOps.Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Report {
    public abstract class ReportDecorator : IReport {
        protected IReport _report;

        protected ReportDecorator(IReport report) {
            _report = report;
        }

        public void Export(IExportStrategy exportStrategy, string fileName) {
            var reportcontent = generate();
            exportStrategy.Export(reportcontent, fileName);
        }

        public virtual string generate() {
            return _report.generate();
        }
    }
}
