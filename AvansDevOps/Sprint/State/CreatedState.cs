using AvansDevOps.Backlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint.SprintState {
    public class CreatedState : MainState {
        public override void AddBacklogItems(Sprint sprint, BacklogItem item) {
            sprint.BacklogItems.Add(item);
        }

        public override void ChangeSprintName(Sprint sprint, string name) {
            sprint.Name = name;
        }

        public override void EndSprint(Sprint sprint) {
            Console.WriteLine("First start the sprint.");
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
