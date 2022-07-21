using GrpcDomain.Interfaces;
using GrpcDomain.Requests;
using GrpcDomain.Responses;

namespace GrpcService.Services
{
    public class GreeterService : IGreeterService
    {
        public Task<HelloResponse> GetGreetingAsync(HelloRequest request)
        {
            return Task.FromResult(new HelloResponse
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
