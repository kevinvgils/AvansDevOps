﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class DeploymentSprint : Sprint {
        public DeploymentSprint(string name) : base(name) {
            Name = name;
        }

        public override void SprintEnded() {
            Console.WriteLine("Sprint Ended Starting Deployment...");
        }
    }
}
