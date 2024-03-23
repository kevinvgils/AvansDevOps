using AvansDevOps.Backlog;
using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint.SprintState {
    public abstract class MainState {
        public abstract void AddBacklogItems(Sprint sprint, BacklogItem item);
        public abstract void ChangeSprintName(Sprint sprint, string name);
        public abstract void SetStartAndEndDate(Sprint sprint, DateOnly startDate, DateOnly endDate);
        public abstract void StartSprint(Sprint sprint);
        public abstract void EndSprint(Sprint sprint);
        public abstract void AddDeveloper(Sprint sprint, User developer);
        public abstract void RemoveDeveloper(Sprint sprint, User developer);
        public abstract void AddTester(Sprint sprint, User tester);
        public abstract void RemoveTester(Sprint sprint, User tester);
        public abstract void SetScrummaster(Sprint sprint, User scrummaster);



    }
}
