using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Git {
    public class GitCommit : GitCommand {
        public override void Execute() {
            Console.WriteLine("git commit -am 'message'");
        }
    }
}
