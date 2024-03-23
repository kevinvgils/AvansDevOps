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

        public void Export(IExportStrategy exportStrategy, string fileName, Sprint.Sprint sprint) {
            var reportcontent = generate(sprint);
            exportStrategy.Export(reportcontent, fileName);
        }

        public virtual string generate(Sprint.Sprint sprint) {
            return _report.generate(sprint);
        }
    }
}
