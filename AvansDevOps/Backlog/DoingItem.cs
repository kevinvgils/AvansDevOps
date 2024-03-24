using AvansDevOps.Git;
using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class DoingItem : BacklogState {
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
            PrintMessageAndThrowException();
        }

        public override void HandleReadyForTesting(BacklogItem context, Sprint.Sprint sprint) {
            if (context.GetActivities().Exists(activity => !activity.GetStatus())) throw new ArgumentException("Some activities are not done yet. Finish them first");
            Console.WriteLine("Moving to ReadyForTesting...");
            context.SetState(new ReadyForTestingItem());
            sprint.NotifyTesters(context);
            context.History.ExecuteCommand(new GitPull());
            context.History.ExecuteCommand(new GitCommit());
            context.History.ExecuteCommand(new GitPush());
        }

        public override void HandleTested(BacklogItem context) {
            PrintMessageAndThrowException();
        }

        public override void HandleTesting(BacklogItem context) {
            PrintMessageAndThrowException();
        }

        public override void HandleToDo(BacklogItem context) {
            Console.WriteLine("Moving back to todo");
            context.SetState(new TodoItem());
        }
    }
}
