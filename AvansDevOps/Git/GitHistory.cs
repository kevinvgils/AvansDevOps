using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Git {
    public class GitHistory {
        private List<GitCommand> Commands = new();

        public void ExecuteCommand(GitCommand command) {
            command.Execute();
            Commands.Add(command);
        }

        public void UndoCommand() {
            Commands.RemoveAt(0);
        }

        public List<GitCommand> GetHistory() {
            return Commands;
        }
    }
}
