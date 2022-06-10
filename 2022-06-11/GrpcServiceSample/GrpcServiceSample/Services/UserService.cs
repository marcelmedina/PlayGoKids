using Grpc.Core;

namespace GrpcServiceSample.Services
{
    public class UserService : GrpcServiceSample.UserService.UserServiceBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<UserResponse> GetUserDetails(UserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserResponse
            {
                FirstName = "John",
                LastName = "Smith",
                Address = new Address()
                {
                    Number = "1A",
                    StreetName = "John Smith Street",
                    Suburb = "Some suburb",
                    City = "The city",
                    Country = "Some country"
                }
            });
        }
    }
}
