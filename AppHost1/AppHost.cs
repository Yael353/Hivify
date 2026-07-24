var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.Ansjon>("web");



builder.Build().Run();
