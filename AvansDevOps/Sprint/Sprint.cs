using AvansDevOps.Backlog;
using AvansDevOps.ScrumRole;
using AvansDevOps.Sprint.SprintState;

namespace AvansDevOps.Sprint {
    public abstract class Sprint {
        public List<User> Members { get; } = new List<User>();
        public List<BacklogItem> BacklogItems { get; } = new();
        public string Name { get; set; }
        private MainState State { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public Sprint(string name) { 
            Name = name;
            State = new CreatedState();
        }

        public abstract void SprintEnded();

        public void addMember(User member) {
            Members.Add(member);
        }
        public void removeMember(User member) {
            Members.Remove(member);
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
    }
}
