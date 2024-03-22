using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Git {
    public class GitPush : GitCommand {
        public override void Execute() {
            Console.WriteLine("git push");
        }
    }
}
