using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class Project {
        public List<Sprint> sprints = new List<Sprint>();

        public void CreateSprint(ISprintFactory sprintFactory) {
            Sprint sprint = sprintFactory.CreateSprint();
            sprints.Add(sprint);
        }
    }
}
