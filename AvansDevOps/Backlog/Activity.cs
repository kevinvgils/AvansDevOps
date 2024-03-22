using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Backlog {
    public class Activity {
        private bool IsDone { get; set; }
        private string Name { get; set; }
        private User? Developer { get; set; }

        public Activity(string name) { 
            Name = name;
        }

        public void Remove() {
            Developer = null;
        }

        public void SetDeveloper(User developer) {
            Developer = developer;
        }

        public User? GetDeveloper() {
            return Developer;
        }

        public void SetStatus(bool status) {
            IsDone = status;
        }

        public bool GetStatus() {
            return IsDone;
        }

        public void SetName(string name) {
            Name = name;
        }

        public string GetName() {
            return Name;
        }
    }
}
