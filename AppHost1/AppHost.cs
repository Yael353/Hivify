var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<Projects.Hivify_Api>("web");



builder.Build().Run();
