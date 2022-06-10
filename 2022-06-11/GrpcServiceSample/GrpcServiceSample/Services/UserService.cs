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
                UserId = 1,
                FirstName = "Bill",
                LastName = "Lumbergh",
                Address = new Address()
                {
                    Number = "1A",
                    StreetName = "Initech Street",
                    Suburb = "Initech Suburb",
                    City = "Austin, Texas",
                    Country = "USA"
                }
            });
        }
    }
}
