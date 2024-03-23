using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class TodoItem : BacklogState {
        private readonly string Message = "Not Allowed first move to 'Ready for Testing'";
        private readonly SystemException ex = new("Not Allowed");

        private void PrintMessageAndThrowException() {
            Console.WriteLine(Message);
            throw ex;
        }
        public override void HandleDoing(BacklogItem context) {
            Console.WriteLine("Moving to Doing...");
            context.SetState(new DoingItem());
        }

        public override void HandleDone(BacklogItem context) {
            PrintMessageAndThrowException();        
        }

        public override void HandleReadyForTesting(BacklogItem context, Sprint.Sprint sprint) {
            Console.WriteLine("First move to Doing...");
            throw new SystemException("Not Allowed first move to doing");

        }

        public override void HandleTested(BacklogItem context) {
            PrintMessageAndThrowException();
        }

        public override void HandleTesting(BacklogItem context) {
            PrintMessageAndThrowException();
        }

        public override void HandleToDo(BacklogItem context) {
            Console.WriteLine("Already in ToDo");
            throw new SystemException("Not Allowed");
        }
    }
}
