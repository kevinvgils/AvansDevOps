using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class Project {
        private readonly List<Sprint> Sprints = new();
        private User Powner;

        public Project(User productOwner) {
            if (productOwner.GetRole() is not ProductOwner) throw new ArgumentException("User should be of role ProductOwner");
            Powner = productOwner;
        }
        public void CreateSprint(ISprintFactory sprintFactory, string sprintName) {
            Sprint sprint = sprintFactory.CreateSprint(sprintName);
            Sprints.Add(sprint);
        }

        public User GetProductOwner() { return Powner; }
        public void SetUser(User productOwner) { Powner = productOwner; }
        public List<Sprint> GetSprints() { return Sprints; }
    }
}
