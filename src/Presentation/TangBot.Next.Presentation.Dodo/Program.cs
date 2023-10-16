using Serilog;
using TangBot.Next.Application.Dodo.Extensions;
using TangBot.Next.Presentation.Dodo;
using TangBot.Next.Presentation.Dodo.Extensions;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureLogging(o =>
{
    o.ClearProviders();
});

builder.ConfigureServices(s =>
{
    s.AddHostedService<DodoHosted>();

    s.AddDodoOpenApiService();
    s.AddEventHandlers();
});

builder.UseSerilog();

var app = builder.Build();

await app.RunAsync();
