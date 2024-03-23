using AvansDevOps.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class TestedItem : BacklogState {
        public override void HandleDoing(BacklogItem context) {
            Console.WriteLine("Not allowed move to ReadyForTesting or done");
        }

        public override void HandleDone(BacklogItem context) {
            //TODO MAKE ONLY DEVELOPER BE ABLE TO DO IT
            Console.WriteLine("Moving to Done...");
            context.SetState(new DoneItem());
        }

        public override void HandleReadyForTesting(BacklogItem context, Sprint.Sprint sprint) {
            Console.WriteLine("Moving to Ready for testing...");
            context.SetState(new ReadyForTestingItem());
            sprint.NotifyTesters(context);
        }

        public override void HandleTested(BacklogItem context) {
            Console.WriteLine("Already in Tested");
        }

        public override void HandleTesting(BacklogItem context) {
            Console.WriteLine("Already tested. Let developer move it to Done or move to ReadyForTesting");
        }

        public override void HandleToDo(BacklogItem context) {
            Console.WriteLine("Let tester test again first. Move it to Ready for testing.");
        }
    }
}
