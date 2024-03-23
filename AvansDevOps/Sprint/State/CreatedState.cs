using AvansDevOps.Backlog;
using AvansDevOps.Notification;
using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint.SprintState {
    public class CreatedState : MainState {
        public override void AddBacklogItems(Sprint sprint, BacklogItem item) {
            sprint.BacklogItems.Add(item);
            sprint.BacklogItems = sprint.BacklogItems.OrderBy(item => item.GetPriority()).ToList();
        }

        public override void AddDeveloper(Sprint sprint, User developer) {
            sprint.Developers.Add(developer);
        }

        public override void AddTester(Sprint sprint, User tester, List<INotificationObserver> channels) {
            sprint.Testers.Add(tester);
            sprint.NotificationManager.Attach(tester, channels);
        }

        public override void ChangeSprintName(Sprint sprint, string name) {
            sprint.Name = name;
        }

        public override void EndSprint(Sprint sprint) {
            Console.WriteLine("First start the sprint.");
            throw new Exception("First start the sprint");
        }

        public override void RemoveDeveloper(Sprint sprint, User developer) {
            sprint.Developers.Remove(developer);
        }

        public override void RemoveTester(Sprint sprint, User tester) {
            sprint.Testers.Remove(tester);
        }

        public override void SetScrummaster(Sprint sprint, User scrummaster) {
            sprint.Smaster = scrummaster;
        }

        public override void SetStartAndEndDate(Sprint sprint, DateOnly startDate, DateOnly endDate) {
            sprint.StartDate = startDate;
            sprint.EndDate = endDate;
        }

        public override void StartSprint(Sprint sprint) {
            sprint.SetState(new DoingState());
        }
    }
}
