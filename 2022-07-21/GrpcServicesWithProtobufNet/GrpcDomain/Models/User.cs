using System.Runtime.Serialization;

namespace GrpcDomain.Models
{
    [DataContract]
    public class User
    {
        [DataMember(Order = 1)]
        public int Id { get; private set; }

        [DataMember(Order = 2)]
        public string FirstName { get; private set; }

        [DataMember(Order = 3)]
        public string LastName { get; private set; }

        [DataMember(Order = 4)]
        public Address Address { get; set; }

        public User() { }

        public User(int id, string firstName, string lastName, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
}
