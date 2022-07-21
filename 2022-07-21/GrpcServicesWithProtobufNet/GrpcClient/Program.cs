using System.Text.Json;
using Grpc.Net.Client;
using GrpcDomain.Interfaces;
using GrpcDomain.Requests;
using ProtoBuf.Grpc.Client;

var channel = GrpcChannel.ForAddress("http://localhost:5000");

var client1 = channel.CreateGrpcService<IGreeterService>();
var greeting = await client1.GetGreetingAsync(new HelloRequest() { Name = "Bill" });

Console.WriteLine(greeting.Message);

var client2 = channel.CreateGrpcService<IUserService>();
var userDetails = await client2.GetUserAsync(new UserRequest() { Id = 1 });

Console.WriteLine(JsonSerializer.Serialize(userDetails));
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
