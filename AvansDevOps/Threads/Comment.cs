using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Threads {
    public class Comment {
        public string Message { get; }
        public User Commenter { get; }

        public Comment(string message, User user) {
            Message = message;
            Commenter = user;
        }
    }
}
