using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class Project {
        private List<Sprint> sprints = new();
        private User productOwner;

        public Project(User productOwner) {
            this.productOwner = productOwner;
        }
        public void CreateSprint(ISprintFactory sprintFactory, string sprintName) {
            Sprint sprint = sprintFactory.CreateSprint(sprintName);
            sprints.Add(sprint);
        }

        public User GetUser() { return productOwner; }
        public void SetUser(User user) { productOwner = user; }
        public List<Sprint> GetSprints() { return sprints; }
    }
}
