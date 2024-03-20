﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class ReviewSprintFactory : ISprintFactory {
        public Sprint CreateSprint() {
            var newSprint = new ReviewSprint();
            return newSprint;
        }
    }
}
