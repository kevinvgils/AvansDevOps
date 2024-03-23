using AvansDevOps.ScrumRole;

namespace AvansDevOps.Backlog {
    public class BacklogItem {
        private User? Developer { get; set; }
        private readonly List<Activity> activities = new();
        private int Priority { get; set; }
        private string Name { get; set; }
        private BacklogState _state { get; set; }

        public BacklogItem(int priority, string name) {
            _state = new TodoItem();
            Priority = priority;
            Name = name;
        }

        public void SetState(BacklogState state) {
            _state = state;
        }

        public void SetPriority(int priority) {
            if (priority < 0) Priority = priority;
        }
        public int GetPriority() {
            return Priority;
        }

        public void SetName(string name) { Name = name; }
        public string GetName() { return Name; }

        public void AddActivity(Activity activity) { 
            activities.Add(activity);
        }

        public void RemoveActivity(Activity activity) {
            activities.Remove(activity);
        }

        public List<Activity> GetActivities() {
            return activities;
        }

        public void UpdateActivity(bool status, Activity activity) {
            var selected = activities.Find(a => a.GetName() == activity.GetName());
            selected?.SetStatus(status);
        }

        public void SetUser(User user) {
            Developer = user;
        }

        public void HandleToDo() {
            _state.HandleToDo(this);
        }
        public void HandleDoing() {
            _state.HandleDoing(this);
        }

        public void HandleReadyForTesting() {
            _state.HandleReadyForTesting(this);
        }

        public void HandleTesting() {
            _state.HandleTesting(this);
        }

        public void HandleTested() {
            _state.HandleTested(this);
        }

        public void HandleDone() {
            _state.HandleDone(this);
        }

        public void NotifyTesters() {
            Console.WriteLine("Notifying testers...");
            // Implementation of notification logic
        }
    }
}
