using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class ReleaseSprint : Sprint {
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
