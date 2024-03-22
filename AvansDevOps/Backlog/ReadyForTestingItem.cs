using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class ReadyForTestingItem : BacklogState {
        public override void HandleDoing(BacklogItem context) {
            Console.WriteLine("Not allowed to go back to Doing. Move to ToDo");
        }

        public override void HandleDone(BacklogItem context) {
            Console.WriteLine("First move to Tested state");
        }

        public override void HandleReadyForTesting(BacklogItem context) {
            Console.WriteLine("Already in ReadyForTesting");
        }

        public override void HandleTested(BacklogItem context) {
            Console.WriteLine("Moving to Tested");
            context.SetState(new TestingItem());
        }

        public override void HandleTesting(BacklogItem context) {
            Console.WriteLine("Moving to Testing");
            context.SetState(new TestingItem());
        }

        public override void HandleToDo(BacklogItem context) {
            throw new NotImplementedException();
        }
    }
}
