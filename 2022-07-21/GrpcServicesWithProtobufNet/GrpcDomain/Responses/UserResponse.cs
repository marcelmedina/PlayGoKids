using System.Runtime.Serialization;
using GrpcDomain.Models;

namespace GrpcDomain.Responses
{
    [DataContract]
    public class UserResponse
    {
        [DataMember(Order = 1)]
        public User User { get; set; }
    }
}
