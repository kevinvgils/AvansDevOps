using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Notification {
    public class NotificationManager : INotificationManager {
        private readonly Dictionary<User, INotificationObserver> _observers = new Dictionary<User, INotificationObserver>(); 
        public void Attach(User user, INotificationObserver observer) {
            _observers.Add(user, observer);
        }

        public void Detach(User user) {
            _observers.Remove(user);
        }

        public void Notify(string message) {
            
            foreach (var observers in _observers.Select(observers => observers.Value)) {
                observers.Update(message);
            }
        }
    }
}
