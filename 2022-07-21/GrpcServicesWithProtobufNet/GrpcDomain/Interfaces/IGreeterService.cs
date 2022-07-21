using GrpcDomain.Requests;
using GrpcDomain.Responses;
using ProtoBuf.Grpc.Configuration;

namespace GrpcDomain.Interfaces
{
    [Service]
    public interface IGreeterService
    {
        [Operation]
        Task<HelloResponse> GetGreetingAsync(HelloRequest request);
    }
}
