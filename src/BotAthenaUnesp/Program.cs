using BotAthenaUnesp;
using BotAthenaUnesp_Domain;
using BotAthenaUnesp_Domain.Interfaces;

IHost host = (IHost)Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHostedService<Worker>();
        services.AddTransient<IService, Service>();
        services.AddTransient<IDocWriter, DocWriter>();
        services.AddTransient<IEncoder, Encoder>();
    })

    .Build();
await host.RunAsync();



