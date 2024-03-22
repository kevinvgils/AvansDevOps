using AvansDevOps.ScrumRole;

namespace AvansDevOps.Backlog {
    public class BacklogItem {
        private User? Developer { get; set; }
        private List<Activity> activities = new();
        private BacklogState _state { get; set; }

        public BacklogItem() {
            _state = new TodoItem();
        }

        public void SetState(BacklogState state) {
            _state = state;
        }

        public void AddActivity(Activity activity) { 
            activities.Add(activity);
        }

        public void RemoveActivity(Activity activity) {
            activities.Remove(activity);
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

        public static void NotifyTesters() {
            Console.WriteLine("Notifying testers...");
            // Implementation of notification logic
        }
    }
}
