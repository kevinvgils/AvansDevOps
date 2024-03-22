using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class DoneItem : BacklogState {
        public override void HandleDoing(BacklogItem context) {
            Console.WriteLine("Already done. Create new item");
        }

        public override void HandleDone(BacklogItem context) {
            Console.WriteLine("Already done. Create new item");
        }

        public override void HandleReadyForTesting(BacklogItem context) {
            Console.WriteLine("Already done. Create new item");
        }

        public override void HandleTested(BacklogItem context) {
            Console.WriteLine("Already done. Create new item");
        }

        public override void HandleTesting(BacklogItem context) {
            Console.WriteLine("Already done. Create new item");
        }

        public override void HandleToDo(BacklogItem context) {
            Console.WriteLine("Already done. Create new item");
        }
    }
}
