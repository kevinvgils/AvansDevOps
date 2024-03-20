using AvansDevOps.ScrumRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Notification {
    public interface INotificationManager {
        void Attach(User user, INotificationObserver observer);
        void Detach(User user);
        void Notify(String message);
    }
}
