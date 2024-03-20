using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class ReleaseSprint : Sprint {
        public List<User> Members { get; } = new List<User>();

        public override void addMember(User member) {
            Members.Add(member);
        }

        public override void removeMember(User member) {
            Members.Remove(member);
        }
        public override void end() {
            throw new NotImplementedException();
        }

        public override void setStatus() {
            throw new NotImplementedException();
        }

        public override void start() {
            Console.WriteLine("Release Sprint Started");
        }
    }
}
