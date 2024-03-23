using AvansDevOps.Backlog;
using AvansDevOps.Export;
using AvansDevOps.Report;
using AvansDevOps.ScrumRole;
using AvansDevOps.Sprint;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Tests {
    [TestFixture]
    public class ReportTests {
        private StringWriter sw;
        private TextWriter originalOutput;

        [SetUp]
        public void RedirectConsoleOutput() {
            // Redirect console output
            sw = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(sw);
        }

        [TearDown]
        public void RestoreConsoleOutput() {
            // Restore original console output
            Console.SetOut(originalOutput);
            sw.Dispose();
        }
        [Test]
        public void TestBaseReportGeneration() {
            // Arrange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            DateOnly startDate = new DateOnly(2024, 3, 23);
            DateOnly endDate = new DateOnly(2024, 4, 12);
            User scrumm = new(new Scrummaster());
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var sprint = project.GetSprint();
            sprint.SetScrummaster(scrumm);
            sprint.SetStartAndEndDate(startDate, endDate);

            // Act
            var baseReport = new BaseReport();
            var generatedReport = baseReport.generate(sprint);

            // Assert
            Assert.Multiple(() => {

                Assert.That(generatedReport, Is.Not.Null);
                Assert.That(generatedReport, Does.Contain("Report: ReviewSprint1"));
            });
        }

        [Test]
        public void TestHeaderDecorator() {
            // Arrange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            DateOnly startDate = new DateOnly(2024, 3, 23);
            DateOnly endDate = new DateOnly(2024, 4, 12);
            User scrumm = new(new Scrummaster());
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var sprint = project.GetSprint();
            sprint.SetScrummaster(scrumm);
            sprint.SetStartAndEndDate(startDate, endDate);
            var baseReport = new BaseReport();
            var headerDecorator = new HeaderDecorator(baseReport);

            // Act
            var decoratedReport = headerDecorator.generate(sprint);

            // Assert
            Assert.That(decoratedReport, Does.StartWith("Header"));
        }

        [Test]
        public void TestFooterDecorator() {
            // Arrange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            DateOnly startDate = new DateOnly(2024, 3, 23);
            DateOnly endDate = new DateOnly(2024, 4, 12);
            User scrumm = new(new Scrummaster());
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var sprint = project.GetSprint();
            sprint.SetScrummaster(scrumm);
            sprint.SetStartAndEndDate(startDate, endDate);
            var baseReport = new BaseReport();
            var footerDecorator = new FooterDecorator(baseReport);

            // Act
            var decoratedReport = footerDecorator.generate(sprint);

            // Assert
            Assert.That(decoratedReport, Does.EndWith("Footer"));
        }
        [Test]
        public void TestExportFunctionality() {
            // Arrange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var sprint = project.GetSprint();
            var baseReport = new BaseReport();
            var pdfStrategy = new PdfStrategy();
            var pngStrategy = new PngStrategy();

            // Act
            baseReport.Export(pdfStrategy, "TestReport.pdf", sprint);
            baseReport.Export(pngStrategy, "TestReport.png", sprint);
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string pngLine = consoleOutputLines[consoleOutputLines.Length - 1];
            string pdfLine = consoleOutputLines[consoleOutputLines.Length - 3];


            // Assert
            Assert.Multiple(() => {

                Assert.That(pngLine, Does.StartWith("PNG"));
                Assert.That(pdfLine, Does.StartWith("PDF"));
            });

        }


    }
}
