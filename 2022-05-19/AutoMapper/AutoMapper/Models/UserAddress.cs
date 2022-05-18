namespace AutoMapperDemo.Models
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public string GetFullName => $"{FirstName}, {LastName}";
    }
}
