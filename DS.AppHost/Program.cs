var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.S_API>("s-api");
builder.AddProject<Projects.S_TextChannels>("s-textchannels");

builder.Build().Run();
