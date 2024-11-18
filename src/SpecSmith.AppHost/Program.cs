using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var databaseServer = builder.AddPostgres("databaseServer").WithDataVolume();
var applicationDatabase = databaseServer.AddDatabase("applicationDatabase");

var app = builder.AddProject<SpecSmith>("app")
    .WithReference(applicationDatabase)
    .WaitFor(databaseServer);

builder.Build().Run();
