using AvansDevOps.Export;
using AvansDevOps.Sprint;

namespace AvansDevOps.Report {
    public class BaseReport : IReport {
        public string generate(Sprint.Sprint sprint) {
            return "Report: " + sprint.Name + "\n\n" +
                "Scrummaster: " + sprint.Smaster + "\n" +
                "BacklogItems: " + sprint.BacklogItems.Count + "\n" + 
                "Start date: " + sprint.EndDate + "\n" + 
                "End date" + sprint.StartDate;
        }

        public void Export(IExportStrategy exportStrategy, string fileName, Sprint.Sprint sprint) {
            string reportContent = generate(sprint);
            exportStrategy.Export(reportContent, fileName);
        }

        public void save() { throw new NotImplementedException(); }
    }
}
