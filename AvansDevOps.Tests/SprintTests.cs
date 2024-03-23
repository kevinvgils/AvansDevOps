using AvansDevOps.Backlog;
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
    public class SprintTests {
        [Test]
        public void US1_3_StartSprint_ShouldStartAndCreateSprintAndBeAbleToChangeData() {
            //Arange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            DateOnly startDate = new DateOnly(2024, 3, 23);
            DateOnly endDate = new DateOnly(2024, 4, 12);
            BacklogItem item1 = new(5, "test item");


            //Act
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var sprint = project.GetSprint();
            sprint.SetStartAndEndDate(startDate, endDate);
            sprint.AddBacklogItems(item1);

            //Arrange
            Assert.That(sprint, Is.Not.Null);
            Assert.That(sprint.EndDate, Is.EqualTo(endDate));
            Assert.That(sprint.StartDate, Is.EqualTo(startDate));
            Assert.That(sprint.Name, Is.EqualTo("ReviewSprint1"));
            Assert.That(sprint.BacklogItems, Has.Count.EqualTo(1));
        }
        [Test]
        public void US1_3_AND_US1_5_StartSprint_WhenSprintInDoingNotAllowedToEditData() {
            //Arange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            DateOnly startDate = new DateOnly(2024, 3, 23);
            DateOnly endDate = new DateOnly(2024, 4, 12);
            BacklogItem item1 = new(5, "test item");
            User developer1 = new(new Developer());
            User tester1 = new(new Tester());
            User scrumm = new(new Scrummaster());


            //Act
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var sprint = project.GetSprint();
            sprint.StartSprint();
            TestDelegate testDelegate = () => sprint.SetStartAndEndDate(startDate, endDate);
            TestDelegate testDelegate2 = () => sprint.AddBacklogItems(item1);
            TestDelegate testDelegate3 = () => sprint.StartSprint();
            TestDelegate testDelegate4 = () => sprint.ChangeSprintName("Test");
            TestDelegate testDelegate5 = () => sprint.AddMember(developer1);
            TestDelegate testDelegate6 = () => sprint.RemoveMember(developer1);
            TestDelegate testDelegate7 = () => sprint.AddTester(tester1);
            TestDelegate testDelegate8 = () => sprint.RemoveTester(tester1);
            TestDelegate testDelegate9 = () => sprint.SetScrummaster(scrumm);


            //Arrange
            Assert.Throws<SystemException>(testDelegate);
            Assert.Throws<SystemException>(testDelegate);
            Assert.Throws<SystemException>(testDelegate3);
            Assert.Throws<SystemException>(testDelegate4);
            Assert.Throws<SystemException>(testDelegate5);
            Assert.Throws<SystemException>(testDelegate6);
            Assert.Throws<SystemException>(testDelegate7);
            Assert.Throws<SystemException>(testDelegate8);
            Assert.Throws<SystemException>(testDelegate9);
        }
        [Test]
        public void US1_3_AND_US1_5_StartSprint_WhenSprintInFinishedNotAllowedToEditData() {
            //Arange
            User productowner = new(new ProductOwner());
            Project project = new(productowner);
            DateOnly startDate = new DateOnly(2024, 3, 23);
            DateOnly endDate = new DateOnly(2024, 4, 12);
            BacklogItem item1 = new(5, "test item");
            User developer1 = new(new Developer());
            User tester1 = new(new Tester());
            User scrumm = new(new Scrummaster());


            //Act
            project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");
            var sprint = project.GetSprint();
            sprint.StartSprint();
            sprint.EndSprint();
            TestDelegate testDelegate = () => sprint.SetStartAndEndDate(startDate, endDate);
            TestDelegate testDelegate2 = () => sprint.AddBacklogItems(item1);
            TestDelegate testDelegate3 = () => sprint.StartSprint();
            TestDelegate testDelegate4 = () => sprint.EndSprint();
            TestDelegate testDelegate5 = () => sprint.ChangeSprintName("Test");
            TestDelegate testDelegate6 = () => sprint.AddMember(developer1);
            TestDelegate testDelegate7 = () => sprint.RemoveMember(developer1);
            TestDelegate testDelegate8 = () => sprint.AddTester(tester1);
            TestDelegate testDelegate9 = () => sprint.RemoveTester(tester1);
            TestDelegate testDelegate10 = () => sprint.SetScrummaster(scrumm);


            //Arrange
            Assert.Throws<SystemException>(testDelegate);
            Assert.Throws<SystemException>(testDelegate);
            Assert.Throws<SystemException>(testDelegate3);
            Assert.Throws<SystemException>(testDelegate4);
            Assert.Throws<SystemException>(testDelegate5);
            Assert.Throws<SystemException>(testDelegate6);
            Assert.Throws<SystemException>(testDelegate7);
            Assert.Throws<SystemException>(testDelegate8);
            Assert.Throws<SystemException>(testDelegate9);
            Assert.Throws<SystemException>(testDelegate10);
        }
    }
}
