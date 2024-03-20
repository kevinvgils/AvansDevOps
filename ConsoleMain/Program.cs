﻿// See https://aka.ms/new-console-template for more information
using AvansDevOps.Export;
using AvansDevOps.Notification;
using AvansDevOps.Report;
using AvansDevOps.ScrumRole;
using AvansDevOps.Sprint;


// NOTIFICATIONS OBSERVER & USER STRATEGY PATTERN
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
Project project = new(productowner);

project.CreateSprint(new ReleaseSprintFactory());

project.CreateSprint(new ReviewSprintFactory());

Console.WriteLine("List of Sprints in the Project:");
foreach (var sprint in project.sprints) {
    sprint.start();
}

//DECORATOR REPORT
IReport basereport = new BaseReport();
Console.WriteLine("Generating Base report:");
Console.WriteLine(basereport.generate());
Console.WriteLine("Generating decorated:");
FooterDecorator footer = new(basereport);
HeaderDecorator headerandfooter = new(footer);
Console.WriteLine(headerandfooter.generate());

// EXPORT STRATEGY
IReport report = new BaseReport();
report.Export(new PNGStrategy(), "report.png");

report = new HeaderDecorator(report);
report = new FooterDecorator(report);

// Export to PDF
report.Export(new PDFStrategy(), "reportDecorated.pdf");


