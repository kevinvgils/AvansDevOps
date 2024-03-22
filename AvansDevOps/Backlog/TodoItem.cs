using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class TodoItem : BacklogState {
        public override void HandleDoing(BacklogItem context) {
            Console.WriteLine("Moving to Doing...");
            context.SetState(new DoingItem());
        }

        public override void HandleDone(BacklogItem context) {
            Console.WriteLine("Not Allowed first move to 'Ready for Testing'");
        }

        public override void HandleReadyForTesting(BacklogItem context) {
            Console.WriteLine("Moving item to Ready for Testing state...");
            context.SetState(new ReadyForTestingItem());
            // Notify testers
            context.NotifyTesters();
        }

        public override void HandleTested(BacklogItem context) {
            Console.WriteLine("Not Allowed first move to 'Ready for Testing'");
        }

        public override void HandleTesting(BacklogItem context) {
            Console.WriteLine("Not Allowed first move to 'Ready for Testing'");
        }

        public override void HandleToDo(BacklogItem context) {
            Console.WriteLine("Already in ToDo");
        }
    }
}
