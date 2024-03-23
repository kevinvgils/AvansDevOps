using AvansDevOps.Backlog;
using AvansDevOps.ScrumRole;
using AvansDevOps.Sprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Tests {
    [TestFixture]
    public class PipelineTests {
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
        public void TestPipeline() {
            //Arange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            DateOnly startDate = new(2024, 3, 23);
            DateOnly endDate = new(2024, 4, 12);


            //Act
            project.CreateSprint(new DeploymentSprintFactory(), "ReviewSprint1");
            var sprint = project.GetSprint();
            sprint.SetStartAndEndDate(startDate, endDate);
            sprint.StartSprint();
            sprint.EndSprint();

            // Assert
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string lastLine = consoleOutputLines[consoleOutputLines.Length - 1];
            Assert.Multiple(() => {
                Assert.That(consoleOutputLines, Has.Length.EqualTo(6));
                Assert.That(lastLine, Is.EqualTo("'Executing Request' Deploy to azure"));
            });
        }
    }
}
