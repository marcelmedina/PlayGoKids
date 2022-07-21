using System.Runtime.Serialization;

namespace GrpcDomain.Requests
{
    [DataContract]
    public class UserRequest
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
    }
}
