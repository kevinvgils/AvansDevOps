using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public abstract class Sprint {
        public List<User> Members { get; }
        public abstract void start();

        public abstract void end();

        public abstract void setStatus();

        public abstract void addMember(User member);
        public abstract void removeMember(User member);
    }
}
