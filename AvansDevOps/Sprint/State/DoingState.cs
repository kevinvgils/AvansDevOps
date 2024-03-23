using AvansDevOps.Backlog;
using AvansDevOps.Notification;
using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;

namespace AvansDevOps.Sprint.SprintState {
    public class DoingState : MainState {
        private const string Message = "Not Allowed";
        private static readonly SystemException ex = new SystemException(Message);

        private void HandleNotAllowedAction() {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void AddBacklogItems(Sprint sprint, BacklogItem item) {
            HandleNotAllowedAction();
        }

        public override void AddDeveloper(Sprint sprint, User developer) {
            HandleNotAllowedAction();
        }

        public override void AddTester(Sprint sprint, User tester, List<INotificationObserver> channels) {
            HandleNotAllowedAction();
        }

        public override void ChangeSprintName(Sprint sprint, string name) {
            HandleNotAllowedAction();
        }

        public override void EndSprint(Sprint sprint) {
            sprint.SetState(new FinishedState());
            sprint.SprintEnded();
        }

        public override void RemoveDeveloper(Sprint sprint, User developer) {
            HandleNotAllowedAction();
        }

        public override void RemoveTester(Sprint sprint, User tester) {
            HandleNotAllowedAction();
        }

        public override void SetScrummaster(Sprint sprint, User scrummaster) {
            HandleNotAllowedAction();
        }

        public override void SetStartAndEndDate(Sprint sprint, DateOnly startDate, DateOnly endDate) {
            HandleNotAllowedAction();
        }

        public override void StartSprint(Sprint sprint) {
            HandleNotAllowedAction();
        }
    }
}
