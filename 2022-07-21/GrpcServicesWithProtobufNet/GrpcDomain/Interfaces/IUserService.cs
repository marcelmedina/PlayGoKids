using System.ServiceModel;
using GrpcDomain.Requests;
using GrpcDomain.Responses;

namespace GrpcDomain.Interfaces
{
    [ServiceContract]
    public interface IUserService
    {
        Task<UserResponse> GetUserAsync(UserRequest request);
    }
}
