using ProtoBuf;

namespace GrpcDomain.Responses
{
    [ProtoContract]
    public class HelloResponse
    {
        [ProtoMember(1)]
        public string Message { get; set; }

        public HelloResponse()
        {
        }
    }
}
