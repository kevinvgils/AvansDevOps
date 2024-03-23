using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class DeploymentSprintFactory : ISprintFactory {
        public Sprint CreateSprint(string name) {
            return new DeploymentSprint(name);
        }
    }
}
