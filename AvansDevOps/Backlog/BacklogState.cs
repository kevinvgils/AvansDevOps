using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public abstract class BacklogState {
        public abstract void HandleToDo(BacklogItem context);
        public abstract void HandleDoing(BacklogItem context);
        public abstract void HandleReadyForTesting(BacklogItem context);
        public abstract void HandleTesting(BacklogItem context);
        public abstract void HandleTested(BacklogItem context);
        public abstract void HandleDone(BacklogItem context);
    }
}
