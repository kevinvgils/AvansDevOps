using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Report {
    public class FooterDecorator : ReportDecorator {
        public FooterDecorator(Report report) : base(report) {
        }

        public override string generate() {
            return $"FooterDecorator({base.generate()})";
        }
    }
}
