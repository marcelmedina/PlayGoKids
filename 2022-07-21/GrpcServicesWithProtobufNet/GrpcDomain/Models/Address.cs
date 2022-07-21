using System.Runtime.Serialization;

namespace GrpcDomain.Models
{
    [DataContract]
    public class Address
    {
        [DataMember(Order = 1)]
        public string Number { get; private set; }

        [DataMember(Order = 2)]
        public string Street { get; private set; }

        [DataMember(Order = 3)]
        public string Suburb { get; private set; }

        [DataMember(Order = 4)]
        public string City { get; private set; }

        [DataMember(Order = 5)]
        public string Country { get; private set; }

        public Address() { }

        public Address(string number, string street, string suburb, string city, string country)
        {
            Number = number;
            Street = street;
            Suburb = suburb;
            City = city;
            Country = country;
        }
    }
}
