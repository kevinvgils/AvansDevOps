using AvansDevOps.Backlog;
using AvansDevOps.Notification;
using AvansDevOps.ScrumRole;
using AvansDevOps.Sprint.SprintState;

namespace AvansDevOps.Sprint {
    public abstract class Sprint {
        public NotificationManager NotificationManager = new();
        public List<User> Developers { get; } = new();
        public List<User> Testers { get; } = new();
        public User? Smaster { get; set; }
        public virtual List<BacklogItem> BacklogItems { get; set; } = new();
        public string Name { get; set; }
        private MainState State { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        protected Sprint(string name) { 
            Name = name;
            State = new CreatedState();
        }

        public abstract void SprintEnded();

        private static bool CheckDevRole(User user) {
            if (user.GetRole() is not Developer) throw new ArgumentException("User should have the role of Developer");
            return true;
        }
        private static bool CheckTesterRole(User user) {
            if (user.GetRole() is not Tester) throw new ArgumentException("User should have the role of Developer");
            return true;
        }
        private static bool CheckScrummasterRole(User user) {
            if (user.GetRole() is not Scrummaster) throw new ArgumentException("User should have the role of Scrummaster");
            return true;
        }
        public void AddMember(User member) {
            if (CheckDevRole(member)) State.AddDeveloper(this, member);
        }
        public void RemoveMember(User member) {
            if (CheckDevRole(member)) State.RemoveDeveloper(this, member);
        }
        public void AddTester(User tester, List<INotificationObserver> channels) {
            if (CheckTesterRole(tester)) State.AddTester(this, tester, channels);
        }
        public void RemoveTester(User tester) {
            if (CheckTesterRole(tester)) State.RemoveTester(this, tester);
        }
        public void SetScrummaster(User scrummaster) {
            if(CheckScrummasterRole(scrummaster)) State.SetScrummaster(this, scrummaster);
        }
        public void ChangeSprintName(string name) {
            State.ChangeSprintName(this, name);
        }
        public void AddBacklogItems(BacklogItem item) {
            State.AddBacklogItems(this, item);
        }
        public void SetStartAndEndDate(DateOnly startDate, DateOnly endDate) {
            State.SetStartAndEndDate(this, startDate, endDate);
        }
        public void StartSprint() {
            State.StartSprint(this);
        }
        public void EndSprint() {
            State.EndSprint(this);
        }
        public void SetState(MainState state) {
            State = state;
        }

        public void NotifyTesters(BacklogItem item) {
            NotificationManager.Notify(item.GetName() + "is ready for testing");
        }
    }
}
