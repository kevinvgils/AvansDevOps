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
    public class ActivityTests {
        [Test]
        public void TestBacklogItem_ToReadyForTestingWhenNotAllActivitysAreDone() {
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");

            var sprint = project.GetSprint();
            BacklogItem item1 = new(5, "test item", sprint);
            Activity activity = new("test activity");
            Activity activity2 = new("test2 activity");
            Activity activity3 = new("test3 activity");

            activity.SetName("Set new Activity name");
            item1.AddActivity(activity);
            item1.AddActivity(activity2); 
            item1.AddActivity(activity3);
            activity2.SetStatus(true);
            activity3.SetStatus(true);
            item1.RemoveActivity(activity3);

            item1.HandleDoing();
            void testDelegate() => item1.HandleReadyForTesting();

            Assert.Multiple(() => {
                Assert.That(activity.GetName(), Is.EqualTo("Set new Activity name"));
                Assert.That(activity.GetStatus(), Is.EqualTo(false));
                Assert.That(activity2.GetStatus(), Is.EqualTo(true));
                Assert.That(item1.GetActivities().Count, Is.EqualTo(2));
                Assert.Throws<ArgumentException>(testDelegate);
            });



        }
    }
}
