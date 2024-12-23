using GraphTestingClient;

namespace GraphQLSampleClient.ServiceExample;

public class MyService(IGraphQlTestingClient client)
{
    public async Task ExecuteQueriesAsync()
    {
        var helloResponse = await client.GetHello.ExecuteAsync();
        Console.WriteLine($"Hello Response: {helloResponse.Data?.Hello}");
 
        var numberResponse = await client.GetNumber.ExecuteAsync();
        Console.WriteLine($"Hello Response: {numberResponse.Data?.GetNumber}");
    }
}