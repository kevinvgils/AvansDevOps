using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Report {
    public abstract class ReportDecorator : Report {
        protected Report _report;

        public ReportDecorator(Report report) {
            _report = report;
        }
        public override string generate() {
            if (this._report != null) {
                return this._report.generate();
            } else {
                return string.Empty;
            }
        }
    }
}
