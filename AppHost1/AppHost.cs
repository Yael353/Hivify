var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.Hivify>("web");



builder.Build().Run();
