var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.MacTechLog_ApiService>("apiservice");

builder.AddProject<Projects.MacTechLog_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.AddProject<Projects.PilotEntryService>("pilotentryservice");

builder.AddProject<Projects.MaintenanceLogsService>("maintenancelogsservice");

builder.Build().Run();
