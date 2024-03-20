using AvansDevOps.Export;

namespace AvansDevOps.Report {
    public class BaseReport : IReport {
        public string generate() {
            return "This is a basic report";
        }

        public void Export(IExportStrategy exportStrategy, string fileName) {
            string reportContent = generate();
            exportStrategy.Export(reportContent, fileName);
        }

        public void save() { throw new NotImplementedException(); }
    }
}
