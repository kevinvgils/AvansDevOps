﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ScrumRole {
    public class ProductOwner : IScrumRole {
        public void execute() {
            Console.WriteLine("Doing ProductOwner Tasks");
        }
    }
}
