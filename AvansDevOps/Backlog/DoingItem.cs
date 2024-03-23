using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class DoingItem : BacklogState {
        private readonly Exception Message = new Exception("Not Allowed first move to 'Ready for Testing'");
        public override void HandleDoing(BacklogItem context) {
            Console.WriteLine("Already in Doing...");
        }

        public override void HandleDone(BacklogItem context) {
            Console.WriteLine("Not Allowed first move to 'Ready for Testing'");
            throw Message;
        }

        public override void HandleReadyForTesting(BacklogItem context, Sprint.Sprint sprint) {
            if (context.GetActivities().Any(activity => !activity.GetStatus())) throw new Exception("Some activities are not done yet. Finish them first");
            Console.WriteLine("Moving to ReadyForTesting...");
            context.SetState(new ReadyForTestingItem());
            sprint.NotifyTesters(context);
        }

        public override void HandleTested(BacklogItem context) {
            Console.WriteLine("Not Allowed first move to 'Ready for Testing'");
            throw Message;
        }

        public override void HandleTesting(BacklogItem context) {
            Console.WriteLine("Not Allowed first move to 'Ready for Testing'");
            throw Message;
        }

        public override void HandleToDo(BacklogItem context) {
            Console.WriteLine("Moving back to todo");
            context.SetState(new TodoItem());
        }
    }
}
