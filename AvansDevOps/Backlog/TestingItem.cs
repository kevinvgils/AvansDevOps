using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class TestingItem : BacklogState {
        private readonly string Message = "Not Allowed!";
        private readonly SystemException ex = new("Not Allowed");

        private void PrintMessageAndThrowException() {
            Console.WriteLine(Message);
            throw ex;
        }
        public override void HandleDoing(BacklogItem context) {
            PrintMessageAndThrowException();
        }
        public override void HandleDone(BacklogItem context) {
            PrintMessageAndThrowException();
        }

        public override void HandleReadyForTesting(BacklogItem context, Sprint.Sprint sprint) {
            PrintMessageAndThrowException();
        }

        public override void HandleTested(BacklogItem context) {
            Console.WriteLine("Moving to tested...");
            context.SetState(new TestedItem());
        }

        public override void HandleTesting(BacklogItem context) {
            PrintMessageAndThrowException();
        }

        public override void HandleToDo(BacklogItem context) {
            context.SetState(new TodoItem());
            context.NotifyDeveloper();
        }
    }
}
