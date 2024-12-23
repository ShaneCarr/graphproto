using GraphQLSampleClient.ServiceExample;
using GraphQLSampleClientNS;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddGraphQlTestingClient()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("http://localhost:4000/graphql");
    });

// Register your custom service
serviceCollection.AddSingleton<MyService>();

// Build the ServiceProvider
var serviceProvider = serviceCollection.BuildServiceProvider();

// Resolve and use MyService
var myService = serviceProvider.GetRequiredService<MyService>();
await myService.ExecuteQueriesAsync();