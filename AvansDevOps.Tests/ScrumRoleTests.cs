using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Tests {
    public class ScrumRoleTests {
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
        public void Developer_test() {
            User developer = new(new Developer());

            developer.PerformRole();
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert.That(consoleOutputLines[0], Is.EqualTo("Doing Developer Tasks"));
        }
        [Test]
        public void Scrummaster_test() {
            User scrummaster = new(new Scrummaster());

            scrummaster.PerformRole();
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert.That(consoleOutputLines[0], Is.EqualTo("Doing Scrummaster Tasks"));
        }
        [Test]
        public void Tester_test() {
            User tester = new(new Tester());

            tester.PerformRole();
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert.That(consoleOutputLines[0], Is.EqualTo("Doing Tester Tasks"));
        }
        [Test]
        public void ProductOwner_test() {
            User productowner = new(new ProductOwner());

            productowner.PerformRole();
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert.That(consoleOutputLines[0], Is.EqualTo("Doing ProductOwner Tasks"));
        }

        [Test]
        public void ChangeRole_Test() {
            User developer = new(new ProductOwner());

            developer.SetRole(new Developer());
            developer.PerformRole();
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            Assert.That(consoleOutputLines[0], Is.EqualTo("Doing Developer Tasks"));
        }
    }
}
