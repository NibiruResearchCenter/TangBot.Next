using Serilog;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureLogging(o =>
{
    o.ClearProviders();
});

builder.UseSerilog();

var app = builder.Build();

await app.RunAsync();
