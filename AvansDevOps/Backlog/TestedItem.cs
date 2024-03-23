using AvansDevOps.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class TestedItem : BacklogState {
        private readonly string Message = "Not Allowed first move to 'Ready for Testing'";
        private readonly SystemException ex = new("Not Allowed");

        private void PrintMessageAndThrowException() {
            Console.WriteLine(Message);
            throw ex;
        }
        public override void HandleDoing(BacklogItem context) {
            PrintMessageAndThrowException();
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
            PrintMessageAndThrowException();
        }

        public override void HandleTesting(BacklogItem context) {
            PrintMessageAndThrowException();
        }

        public override void HandleToDo(BacklogItem context) {
            PrintMessageAndThrowException();
        }
    }
}
