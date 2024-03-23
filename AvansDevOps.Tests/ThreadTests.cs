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
    public class ThreadTests {
        [Test]
        public void ThreadAndCommentTest() {
            // Arrange
            User productowner = new(new ProductOwner());
            User developer = new(new Developer());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");

            // Act
            var backlogItem = new BacklogItem(1, "Sample Backlog Item", project.GetSprint());
            backlogItem.Thread.AddComment(new Threads.Comment("Hallo eerste comment", developer));

            // Assert
            Assert.That(backlogItem.Thread, Is.Not.Null);
            Assert.That(backlogItem.Thread.GetAllComments().Count, Is.EqualTo(1));
            Assert.That(backlogItem.Thread.GetAllComments()[0].Message, Is.EqualTo("Hallo eerste comment"));
        }
    }
}
