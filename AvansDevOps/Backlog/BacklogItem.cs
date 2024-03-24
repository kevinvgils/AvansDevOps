using AvansDevOps.Git;
using AvansDevOps.Notification;
using AvansDevOps.ScrumRole;
using AvansDevOps.Threads;
using Thread = AvansDevOps.Threads.Thread;

namespace AvansDevOps.Backlog {
    public class BacklogItem {
        public GitHistory History = new();
        public NotificationManager NotificationManager { get; set; } = new();
        private Sprint.Sprint Sprint { get; set; }
        private User? Developer { get; set; }
        private readonly List<Activity> activities = new();
        private int Priority { get; set; }
        private string Name { get; set; }
        private BacklogState _state { get; set; }
        public Thread Thread { get; set; } = new();

        public BacklogItem(int priority, string name, Sprint.Sprint sprint) {
            _state = new TodoItem();
            Priority = priority;
            Name = name;
            Sprint = sprint;
            History.ExecuteCommand(new GitBranch());
        }

        public void SetState(BacklogState state) {
            _state = state;
        }
        public BacklogState GetState() {
            return _state;
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

        public void SetDeveloper(User developer, List<INotificationObserver> channels) {
            Developer = developer;
            NotificationManager.Attach(developer, channels);
        }

        public void HandleToDo() {
            _state.HandleToDo(this);
        }
        public void HandleDoing() {
            _state.HandleDoing(this);
        }

        public void HandleReadyForTesting() {
            _state.HandleReadyForTesting(this, Sprint);
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

        public void NotifyDeveloper() {
            NotificationManager.Notify("Moved back to ToDo. Didn't meet Definition of Done in testing");
        }
    }
}
