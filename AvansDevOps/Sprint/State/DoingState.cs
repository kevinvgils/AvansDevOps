using AvansDevOps.Backlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint.SprintState {
    public class DoingState : MainState {
        private string Message = "Not Allowed";
        public override void AddBacklogItems(Sprint sprint, BacklogItem item) {
            Console.WriteLine(Message);
        }

        public override void ChangeSprintName(Sprint sprint, string name) {
            Console.WriteLine(Message);
        }

        public override void EndSprint(Sprint sprint) {
            sprint.SetState(new FinishedState());
        }

        public override void SetStartAndEndDate(Sprint sprint, DateOnly startDate, DateOnly endDate) {
            Console.WriteLine(Message);
        }

        public override void StartSprint(Sprint sprint) {
            Console.WriteLine(Message);
        }
    }
}
