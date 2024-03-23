using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Notification {
    public class NotificationManager : INotificationManager {
        private readonly Dictionary<User, List<INotificationObserver>> _observers = new(); 
        public void Attach(User user, List<INotificationObserver> channels) {
            _observers.Add(user, channels);
        }

        public void Detach(User user) {
            _observers.Remove(user);
        }

        public void Notify(string message) {
            
            foreach (var observers in _observers.Select(observers => observers.Value)) {
                foreach (var observer in observers) { observer.Update(message); }
            }
        }
    }
}
