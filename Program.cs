using tankmonitor_service.Configs;
using tankmonitor_service.Workers;

// Create a new ConfigurationBuilder object and add the appsettings.json file
ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.AddJsonFile("appsettings.json", false, true);

// Build the configuration
IConfigurationRoot configuration = configurationBuilder.Build();

// Create a new WorkerConfiguration object and set its properties
// from the appsettings.json
WorkerConfiguration workerConfiguration = new WorkerConfiguration();
configuration.GetSection("WorkerConfiguration").Bind(workerConfiguration);

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Add the workerConfiguration so I can use it in the workers
        services.AddSingleton(workerConfiguration);
        services.AddSingleton<IHostedService, FuelTotals>();
    })
    .Build();

host.Run();
