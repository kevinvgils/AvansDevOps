using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class TestingItem : BacklogState {
        public override void HandleDoing(BacklogItem context) {
            Console.WriteLine("Not allowed move to ToDo");
        }
        public override void HandleDone(BacklogItem context) {
            Console.WriteLine("FIRST MOVE TO TESTED");
        }

        public override void HandleReadyForTesting(BacklogItem context, Sprint.Sprint sprint) {
            Console.WriteLine("You're already testing");
        }

        public override void HandleTested(BacklogItem context) {
            Console.WriteLine("Moving to tested...");
            context.SetState(new TestedItem());
        }

        public override void HandleTesting(BacklogItem context) {
            Console.WriteLine("Already in Testing");
        }

        public override void HandleToDo(BacklogItem context) {
            context.SetState(new TodoItem());
            context.NotifyDeveloper();
        }
    }
}
