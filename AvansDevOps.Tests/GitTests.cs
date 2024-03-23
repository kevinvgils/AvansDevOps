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
    public class GitTests {
        [Test]
        public void GitHistoryTest() {
            // Arrange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var sprint = project.GetSprint();
            BacklogItem item1 = new(5, "test item", sprint);

            // Act
            sprint.AddBacklogItems(item1);
            item1.HandleDoing();
            item1.HandleReadyForTesting();

            // Assert
            Assert.That(item1.History.GetHistory(), Has.Count.EqualTo(4));
        }
        [Test]
        public void GitHistoryUndoingCommands() {
            // Arrange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var sprint = project.GetSprint();
            BacklogItem item1 = new(5, "test item", sprint);

            // Act
            sprint.AddBacklogItems(item1);
            item1.HandleDoing();
            item1.HandleReadyForTesting();
            item1.History.UndoCommand();
            item1.History.UndoCommand();

            // Assert
            Assert.That(item1.History.GetHistory(), Has.Count.EqualTo(2));
        }

    }
}
