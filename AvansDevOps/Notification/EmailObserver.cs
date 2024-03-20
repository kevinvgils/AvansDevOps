using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Notification {
    public class EmailObserver : INotificationObserver {
        public void Update(string message) {
            Console.WriteLine("Sending Email message: " + message);
        }
    }
}
