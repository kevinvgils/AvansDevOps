// See https://aka.ms/new-console-template for more information
using AvansDevOps.Notification;
using AvansDevOps.ScrumRole;

var notificationManager = new NotificationManager();

var user1 = new User();
var user2 = new User();

user1.setRole(new Developer());
user2.setRole(new Scrummaster());

var slack = new SlackObserver();
var email = new EmailObserver();

notificationManager.Attach(user1, slack);
notificationManager.Attach(user2, email);

notificationManager.Notify("Hallo dit is het bericht");


