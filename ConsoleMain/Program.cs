// See https://aka.ms/new-console-template for more information
using AvansDevOps.Notification;
using AvansDevOps.ScrumRole;
using AvansDevOps.Sprint;


// NOTIFICATIONS TEST EN USER ROLES
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


// SPRINT FACTORY
var productowner = new User();
productowner.setRole(new ProductOwner());
Project project = new Project(productowner);

// Create and add release sprints
project.CreateSprint(new ReleaseSprintFactory());

// Create and add backlog sprints
project.CreateSprint(new ReviewSprintFactory());

// Display the list of sprints in the project
Console.WriteLine("List of Sprints in the Project:");
foreach (var sprint in project.sprints) {
    sprint.start();
}


