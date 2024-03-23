using AvansDevOps.Backlog;
using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint.SprintState {
    public class FinishedState : MainState {
        private string Message = "Sprint already ended";
        private SystemException ex = new("Not Allowed");

        public override void AddBacklogItems(Sprint sprint, BacklogItem item) {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void AddDeveloper(Sprint sprint, User developer) {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void AddTester(Sprint sprint, User tester) {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void ChangeSprintName(Sprint sprint, string name) {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void EndSprint(Sprint sprint) {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void RemoveDeveloper(Sprint sprint, User developer) {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void RemoveTester(Sprint sprint, User tester) {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void SetScrummaster(Sprint sprint, User scrummaster) {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void SetStartAndEndDate(Sprint sprint, DateOnly startDate, DateOnly endDate) {
            Console.WriteLine(Message);
            throw ex;
        }

        public override void StartSprint(Sprint sprint) {
            Console.WriteLine(Message);
            throw ex;
        }
    }
}
