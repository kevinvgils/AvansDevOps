using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Threads {
    public class Thread {
        private List<Comment> Comments = new();

        public void AddComment(Comment comment) { 
            Comments.Add(comment);
        }

        public List<Comment> GetAllComments() {
            return Comments;
        }
    }
}
