//// See https://aka.ms/new-console-template for more information
//using AvansDevOps.Backlog;
//using AvansDevOps.Export;
//using AvansDevOps.Notification;
//using AvansDevOps.Report;
//using AvansDevOps.ScrumRole;
//using AvansDevOps.Sprint;


//// NOTIFICATIONS OBSERVER & USER STRATEGY PATTERN
//var notificationManager = new NotificationManager();

//var user1 = new User(new Developer());
//var user2 = new User(new Scrummaster());

//var slack = new SlackObserver();
//var email = new EmailObserver();

//var list = new List<INotificationObserver> {
//    slack,
//    email
//};

//notificationManager.Attach(user1, list);
//notificationManager.Attach(user2, list);

//notificationManager.Notify("Hallo dit is het bericht");


//// SPRINT FACTORY
//User productowner = new(new ProductOwner());
//Project project = new(productowner);

//project.CreateSprint(new DeploymentSprintFactory(), "DeploymentSprint1");

//project.CreateSprint(new ReviewSprintFactory(), "ReviewSprint1");

//Console.WriteLine("List of Sprints in the Project:");
//foreach (var sprint in project.GetSprints()) {
////    sprint.EndSprint();
//    sprint.StartSprint();
//    sprint.EndSprint();
//}
//var sprintr = project.GetSprint();
////DECORATOR REPORT
//IReport basereport = new BaseReport();
//Console.WriteLine("Generating Base report:");
//Console.WriteLine(basereport.generate(sprintr));
//Console.WriteLine("Generating decorated:");
//FooterDecorator footer = new(basereport);
//HeaderDecorator headerandfooter = new(footer);
//Console.WriteLine(headerandfooter.generate(sprintr));

//// EXPORT STRATEGY
//IReport report = new BaseReport();
//report.Export(new PngStrategy(), "report.png", sprintr);

//report = new HeaderDecorator(report);
//report = new FooterDecorator(report);

//// Export to PDF
//report.Export(new PdfStrategy(), "reportDecorated.pdf", sprintr);


////BACKLOGITEMS
//BacklogItem context = new(5, "test item", project.GetSprint());

//// Sample workflow
//context.HandleDoing();
//context.HandleReadyForTesting();
//context.HandleTesting();
//context.HandleTested();
//context.HandleDone();

//// Trying to perform invalid state transition
//context.HandleTesting();


