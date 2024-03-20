using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Notification {
    public class SlackObserver : INotificationObserver {
        public void Update(string message) {
           Console.WriteLine("Sending Slack message: " + message);
        }
    }
}
