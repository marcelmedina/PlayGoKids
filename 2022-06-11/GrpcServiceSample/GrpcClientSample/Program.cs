using System.Text.Json;
using Grpc.Net.Client;
using GrpcServiceSample;

var channel = GrpcChannel.ForAddress("https://localhost:7147");
var client = new UserService.UserServiceClient(channel);

var userDetails = await client.GetUserDetailsAsync(new UserRequest() {UserId = 1});

Console.WriteLine(JsonSerializer.Serialize(userDetails));
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
