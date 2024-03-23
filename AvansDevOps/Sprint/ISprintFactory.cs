using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public interface ISprintFactory {
        Sprint CreateSprint(string name);
    }
}
