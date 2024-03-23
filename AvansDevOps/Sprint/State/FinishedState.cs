using AvansDevOps.Backlog;
using AvansDevOps.Notification;
using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;

namespace AvansDevOps.Sprint.SprintState {
    public class FinishedState : MainState {
        private readonly string Message = "Sprint already ended";
        private readonly SystemException ex = new("Not Allowed");

        private void PrintMessageAndThrowException() {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void AddBacklogItems(Sprint sprint, BacklogItem item) {
            PrintMessageAndThrowException();
        }

        public override void AddDeveloper(Sprint sprint, User developer) {
            PrintMessageAndThrowException();
        }

        public override void AddTester(Sprint sprint, User tester, List<INotificationObserver> channels) {
            PrintMessageAndThrowException();
        }

        public override void ChangeSprintName(Sprint sprint, string name) {
            PrintMessageAndThrowException();
        }

        public override void EndSprint(Sprint sprint) {
            PrintMessageAndThrowException();
        }

        public override void RemoveDeveloper(Sprint sprint, User developer) {
            PrintMessageAndThrowException();
        }

        public override void RemoveTester(Sprint sprint, User tester) {
            PrintMessageAndThrowException();
        }

        public override void SetScrummaster(Sprint sprint, User scrummaster) {
            PrintMessageAndThrowException();
        }

        public override void SetStartAndEndDate(Sprint sprint, DateOnly startDate, DateOnly endDate) {
            PrintMessageAndThrowException();
        }

        public override void StartSprint(Sprint sprint) {
            PrintMessageAndThrowException();
        }
    }
}
