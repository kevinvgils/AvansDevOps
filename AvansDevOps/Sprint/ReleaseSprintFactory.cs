﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class ReleaseSprintFactory : ISprintFactory {
        public Sprint CreateSprint() {
            return new ReleaseSprint();
        }
    }
}
