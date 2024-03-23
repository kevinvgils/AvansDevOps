using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class ReviewSprint : Sprint {
        public ReviewSprint(string name) : base(name) {
            Name = name;
        }

        public override void SprintEnded() {
            Console.WriteLine("Sprint ended. Starting Review....");
        }
    }
}
