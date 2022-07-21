using ProtoBuf;

namespace GrpcDomain.Requests
{
    [ProtoContract]
    public class HelloRequest
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        public HelloRequest()
        {
        }
    }
}
