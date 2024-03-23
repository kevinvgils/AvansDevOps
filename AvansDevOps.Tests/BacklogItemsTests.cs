using AvansDevOps.Backlog;
using AvansDevOps.ScrumRole;
using AvansDevOps.Sprint;

namespace AvansDevOps.Tests {
    [TestFixture]
    public class BacklogItemsTests {
        [Test]
        public void US1_1AddBacklogItem_ShouldIncreaseBacklogCount() {
            // Arrange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            BacklogItem item1 = new(5, "test item");
            BacklogItem item2 = new(3, "test item");
            BacklogItem item3 = new(1, "test item");

            var sprint = project.GetSprint();


            // Act
            sprint.AddBacklogItems(item2);
            sprint.AddBacklogItems(item1);
            sprint.AddBacklogItems(item3);

            // Assert
            Assert.That(sprint.BacklogItems, Has.Count.EqualTo(3));
            Assert.That(item1.GetPriority(), Is.EqualTo(5));
        }

        [Test]
        public void US1_1PrioritizeBacklog_ShouldOrderItemsByPriority() {
            // Arrange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            BacklogItem item1 = new(5, "Item 1");
            BacklogItem item2 = new(1, "Item 2");
            BacklogItem item3 = new(3, "Item 3");

            var sprint = project.GetSprint();


            // Act
            sprint.AddBacklogItems(item2);
            sprint.AddBacklogItems(item1);
            sprint.AddBacklogItems(item3);

            // Assert
            Assert.That(sprint.BacklogItems[0].GetName(), Is.EqualTo("Item 2"));
            Assert.That(sprint.BacklogItems[1].GetName(), Is.EqualTo("Item 3"));
            Assert.That(sprint.BacklogItems[2].GetName(), Is.EqualTo("Item 1"));
        }
        [Test]
        public void US1_2AddActivityToBacklogItem_ShouldAddActivity() {
            // Arrange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            BacklogItem item1 = new(5, "Item 1");
            BacklogItem item2 = new(1, "Item 2");
            BacklogItem item3 = new(3, "Item 3");

            var sprint = project.GetSprint();

            var activity = new Activity("Test activity");


            // Act
            sprint.AddBacklogItems(item2);
            sprint.AddBacklogItems(item1);
            sprint.AddBacklogItems(item3);
            sprint.BacklogItems[0].AddActivity(activity);
            List<Activity> activities = sprint.BacklogItems[0].GetActivities();
            // Assert
            Assert.That(sprint.BacklogItems[0].GetActivities().Count, Is.EqualTo(1));
            Assert.That(activities[0].GetName(), Is.EqualTo("Test activity"));
        }
    }
}