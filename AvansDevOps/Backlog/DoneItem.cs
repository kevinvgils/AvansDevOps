using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class DoneItem : BacklogState {
        public string message = "Already done. Create a new item";
        public override void HandleDoing(BacklogItem context) {
            Console.WriteLine(message);
        }

        public override void HandleDone(BacklogItem context) {
            Console.WriteLine(message);
        }

        public override void HandleReadyForTesting(BacklogItem context) {
            Console.WriteLine(message);
        }

        public override void HandleTested(BacklogItem context) {
            Console.WriteLine(message);
        }

        public override void HandleTesting(BacklogItem context) {
            Console.WriteLine(message);
        }

        public override void HandleToDo(BacklogItem context) {
            Console.WriteLine(message);
        }
    }
}
