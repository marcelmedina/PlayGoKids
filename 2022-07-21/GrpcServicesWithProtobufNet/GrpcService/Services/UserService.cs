using GrpcDomain.Interfaces;
using GrpcDomain.Requests;
using GrpcDomain.Responses;

namespace GrpcService.Services
{
    public class UserService : IUserService
    {
        public Task<UserResponse> GetUserAsync(UserRequest request)
        {
            return Task.FromResult(new UserResponse
            {
                User = new GrpcDomain.Models.User(request.Id, "Bill", "Lumbergh",
                    new GrpcDomain.Models.Address("1A", "Initech Street", "Initech Suburb", "Austin, Texas", "USA"))
            });
        }
    }
}
