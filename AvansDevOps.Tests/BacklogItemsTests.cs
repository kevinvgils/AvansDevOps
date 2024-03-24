using AvansDevOps.Backlog;
using AvansDevOps.Notification;
using AvansDevOps.ScrumRole;
using AvansDevOps.Sprint;
using Moq;

namespace AvansDevOps.Tests {
    [TestFixture]
    public class BacklogItemsTests {
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
        public void US1_1AddBacklogItem_ShouldIncreaseBacklogCount() {
            // Arrange
            var productOwnerMock = new Mock<User>(MockBehavior.Strict, new ProductOwner());
            var sprintFactoryMock = new Mock<ISprintFactory>();
            var sprintMock = new Mock<Sprint.Sprint>("ReviewSprint1");
            var item1 = new BacklogItem(5, "test item", sprintMock.Object);
            var item2 = new BacklogItem(3, "test item", sprintMock.Object);
            var item3 = new BacklogItem(1, "test item", sprintMock.Object);

            sprintFactoryMock.Setup(f => f.CreateSprint("ReviewSprint1")).Returns(sprintMock.Object);

            sprintMock.SetupGet(s => s.BacklogItems).Returns(new List<BacklogItem>());

            // Act
            sprintMock.Object.AddBacklogItems(item2);
            sprintMock.Object.AddBacklogItems(item1);
            sprintMock.Object.AddBacklogItems(item3);
            Assert.Multiple(() => {

                // Assert
                Assert.That(sprintMock.Object.BacklogItems.Count, Is.EqualTo(3));
                Assert.That(item1.GetPriority(), Is.EqualTo(5));
            });
        }

        [Test]
        public void US1_1PrioritizeBacklog_ShouldOrderItemsByPriority() {
            // Arrange
            var productOwnerMock = new Mock<User>(MockBehavior.Strict, new ProductOwner());
            var sprintFactoryMock = new Mock<ISprintFactory>();
            var sprintMock = new Mock<Sprint.Sprint>("ReviewSprint1");

            sprintFactoryMock.Setup(f => f.CreateSprint("ReviewSprint1")).Returns(sprintMock.Object);

            var backlogItems = new List<BacklogItem>
            {
                new BacklogItem(5, "Item 1", sprintMock.Object),
                new BacklogItem(1, "Item 3", sprintMock.Object),
                new BacklogItem(3, "Item 2", sprintMock.Object)
            };

            sprintMock.SetupGet(s => s.BacklogItems).Returns(backlogItems);

            // Act
            var orderedBacklogItems = backlogItems.OrderBy(item => item.GetPriority()).ToList();
            Assert.Multiple(() => {

                // Assert
                Assert.That(orderedBacklogItems[0].GetName(), Is.EqualTo("Item 3"));
                Assert.That(orderedBacklogItems[1].GetName(), Is.EqualTo("Item 2"));
                Assert.That(orderedBacklogItems[2].GetName(), Is.EqualTo("Item 1"));
            });
        }

        [Test]
        public void US1_2AddActivityToBacklogItem_ShouldAddActivity() {
            // Arrange
            var productOwnerMock = new Mock<User>(MockBehavior.Strict, new ProductOwner());
            var sprintFactoryMock = new Mock<ISprintFactory>();
            var sprintMock = new Mock<Sprint.Sprint>("ReviewSprint1");

            sprintFactoryMock.Setup(f => f.CreateSprint("ReviewSprint1")).Returns(sprintMock.Object);

            var item1 = new BacklogItem(5, "test item", sprintMock.Object);
            var item2 = new BacklogItem(3, "test item", sprintMock.Object);
            var item3 = new BacklogItem(1, "test item", sprintMock.Object);

            var activity = new Activity("Test activity");

            sprintMock.SetupGet(s => s.BacklogItems).Returns(new List<BacklogItem>());

            // Act
            sprintMock.Object.AddBacklogItems(item2);
            sprintMock.Object.AddBacklogItems(item1);
            sprintMock.Object.AddBacklogItems(item3);
            sprintMock.Object.BacklogItems[0].AddActivity(activity);

            // Assert
            Assert.That(sprintMock.Object.BacklogItems[0].GetActivities().Count, Is.EqualTo(1));
            Assert.That(sprintMock.Object.BacklogItems[0].GetActivities()[0].GetName(), Is.EqualTo("Test activity"));
        }

        [Test]
        public void NotifyDeveloper_Test() {
            // Arrange
            User productowner = new(new ProductOwner());
            User developer = new(new Developer());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var channelsMock = new List<INotificationObserver> {
                new SlackObserver()
            };
            var backlogItem = new BacklogItem(1, "Sample Backlog Item", project.GetSprint());


            backlogItem.SetDeveloper(developer, channelsMock);

            // Act
            backlogItem.HandleDoing();
            backlogItem.HandleReadyForTesting();
            backlogItem.HandleTesting();
            backlogItem.HandleToDo();
            // Assert
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string lastLine = consoleOutputLines[consoleOutputLines.Length - 1];
            Assert.That(lastLine, Is.EqualTo("Sending Slack message: Moved back to ToDo. Didn't meet Definition of Done in testing"));
        }

        [Test]
        public void NotifyTesters_Test() {
            // Arrange
            User productowner = new(new ProductOwner());
            User developer = new(new Developer());
            User tester1 = new(new Tester());
            User tester2 = new(new Tester());

            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var channelsMock = new List<INotificationObserver> {
                new SlackObserver()
            };
            var backlogItem = new BacklogItem(1, "Sample Backlog Item", project.GetSprint());

            var sprint = project.GetSprint();
            sprint.AddTester(tester1, channelsMock);
            sprint.AddTester(tester2, channelsMock);
            backlogItem.SetDeveloper(developer, channelsMock);

            // Act
            backlogItem.HandleDoing();
            backlogItem.HandleReadyForTesting();
            // Assert
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string lastLine = consoleOutputLines[consoleOutputLines.Length - 4];
            Assert.That(lastLine, Is.EqualTo("Sending Slack message: Sample Backlog Itemis ready for testing"));
        }

        [Test]
        public void HandleDoneBacklogItem() {
            // Arrange
            User productowner = new(new ProductOwner());
            User developer = new(new Developer());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var channelsMock = new List<INotificationObserver> {
                new SlackObserver()
            };
            var backlogItem = new BacklogItem(1, "Sample Backlog Item", project.GetSprint());


            backlogItem.SetDeveloper(developer, channelsMock);

            // Act
            backlogItem.HandleDoing();
            backlogItem.HandleReadyForTesting();
            backlogItem.HandleTesting();
            backlogItem.HandleTested();
            backlogItem.HandleDone();
            void testDelegate() => backlogItem.HandleReadyForTesting();
            void testDelegate1() => backlogItem.HandleDone();
            void testDelegate2() => backlogItem.HandleToDo();
            void testDelegate3() => backlogItem.HandleTested();
            void testDelegate4() => backlogItem.HandleTesting();
            void testDelegate5() => backlogItem.HandleDoing();
            // Assert
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string doneLine = consoleOutputLines[consoleOutputLines.Length - 1];
            Assert.Multiple(() => {
                Assert.That(doneLine, Is.EqualTo("Moving to Done..."));
                Assert.Throws<SystemException>(testDelegate);
                Assert.Throws<SystemException>(testDelegate1);
                Assert.Throws<SystemException>(testDelegate2);
                Assert.Throws<SystemException>(testDelegate3);
                Assert.Throws<SystemException>(testDelegate4);
                Assert.Throws<SystemException>(testDelegate5);
            });
        }

        [Test]
        public void HandleReadyForTestingStateBacklogItem() {
            // Arrange
            User productowner = new(new ProductOwner());
            User developer = new(new Developer());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var channelsMock = new List<INotificationObserver> {
                new SlackObserver()
            };
            var backlogItem = new BacklogItem(1, "Sample Backlog Item", project.GetSprint());
            backlogItem.SetDeveloper(developer, channelsMock);

            // Act
            backlogItem.HandleDoing();
            backlogItem.HandleReadyForTesting();
            void testDelegate5() => backlogItem.HandleDoing();
            void testDelegate1() => backlogItem.HandleDone();
            void testDelegate() => backlogItem.HandleReadyForTesting();
            void testDelegate2() => backlogItem.HandleToDo();
            void testDelegate6() => backlogItem.HandleTested();
            // Assert
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string doneLine = consoleOutputLines[consoleOutputLines.Length - 1];
            Assert.Multiple(() => {
                Assert.Throws<SystemException>(testDelegate);
                Assert.Throws<SystemException>(testDelegate1);
                Assert.Throws<SystemException>(testDelegate2);
                Assert.Throws<SystemException>(testDelegate5);
                Assert.DoesNotThrow(testDelegate6);
                var state = backlogItem.GetState() is TestedItem;
                Assert.That(state, Is.True);

            });
        }


        [Test]
        public void HandleTestedStateBacklogItem() {
            // Arrange
            User productowner = new(new ProductOwner());
            User developer = new(new Developer());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var channelsMock = new List<INotificationObserver> {
                new SlackObserver()
            };
            var backlogItem = new BacklogItem(1, "Sample Backlog Item", project.GetSprint());
            backlogItem.SetDeveloper(developer, channelsMock);

            // Act
            backlogItem.HandleDoing();
            backlogItem.HandleReadyForTesting();
            backlogItem.HandleTesting();
            backlogItem.HandleTested();
            void testDelegate5() => backlogItem.HandleDoing();
            void testDelegate() => backlogItem.HandleReadyForTesting();
            void testDelegate2() => backlogItem.HandleToDo();
            void testDelegate3() => backlogItem.HandleTesting();
            void testDelegate6() => backlogItem.HandleTested();
            // Assert
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string doneLine = consoleOutputLines[consoleOutputLines.Length - 1];
            Assert.Multiple(() => {
                Assert.Throws<SystemException>(testDelegate2);
                Assert.Throws<SystemException>(testDelegate3);
                Assert.Throws<SystemException>(testDelegate5);
                Assert.Throws<SystemException>(testDelegate6);
                Assert.DoesNotThrow(testDelegate);

            });
        }

        [Test]
        public void HandleTodoStateBacklogItem() {
            // Arrange
            User productowner = new(new ProductOwner());
            User developer = new(new Developer());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var channelsMock = new List<INotificationObserver> {
                new SlackObserver()
            };
            var backlogItem = new BacklogItem(1, "Sample Backlog Item", project.GetSprint());
            backlogItem.SetDeveloper(developer, channelsMock);

            // Act
            void testDelegate5() => backlogItem.HandleDone();
            void testDelegate() => backlogItem.HandleReadyForTesting();
            void testDelegate2() => backlogItem.HandleToDo();
            void testDelegate3() => backlogItem.HandleTesting();
            void testDelegate6() => backlogItem.HandleTested();
            // Assert
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string doneLine = consoleOutputLines[consoleOutputLines.Length - 1];
            Assert.Multiple(() => {
                Assert.Throws<SystemException>(testDelegate2);
                Assert.Throws<SystemException>(testDelegate3);
                Assert.Throws<SystemException>(testDelegate5);
                Assert.Throws<SystemException>(testDelegate6);
                Assert.Throws<SystemException>(testDelegate);

            });
        }

        [Test]
        public void HandleDoingStateBacklogItem() {
            // Arrange
            User productowner = new(new ProductOwner());
            User developer = new(new Developer());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var channelsMock = new List<INotificationObserver> {
                new SlackObserver()
            };
            var backlogItem = new BacklogItem(1, "Sample Backlog Item", project.GetSprint());
            backlogItem.SetDeveloper(developer, channelsMock);

            // Act
            backlogItem.HandleDoing();
            void testDelegate5() => backlogItem.HandleDoing();
            void testDelegate() => backlogItem.HandleDone();
            void testDelegate3() => backlogItem.HandleTesting();
            void testDelegate6() => backlogItem.HandleTested();
            // Assert
            string[] consoleOutputLines = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string doneLine = consoleOutputLines[consoleOutputLines.Length - 1];
            Assert.Multiple(() => {
                Assert.Throws<SystemException>(testDelegate3);
                Assert.Throws<SystemException>(testDelegate5);
                Assert.Throws<SystemException>(testDelegate6);
                Assert.Throws<SystemException>(testDelegate);

            });
        }
    }
}