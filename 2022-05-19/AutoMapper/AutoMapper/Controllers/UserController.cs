using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapperDemo.Models;
using AutoMapperDemo.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = GetUserList();

            var usersViewModel = _mapper.Map<List<UserViewModel>>(users);

            return Ok(usersViewModel);
        }

        [HttpGet("GetUsersProjectTo")]
        public IActionResult GetUsersProjectTo()
        {
            var users = GetUserList();

            var usersViewModel = users
                .AsQueryable()
                .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
                .ToList();

            return Ok(usersViewModel);
        }

        [HttpGet("GetUserNames")]
        public IActionResult GetUserNames()
        {
            var users = GetUserList();

            var userNamesViewModel = _mapper.Map<List<UserNameViewModel>>(users);
            var mappedUserNames = _mapper.Map<List<User>>(userNamesViewModel);

            //return Ok(userNamesViewModel);
            return Ok(mappedUserNames);
        }

        [HttpGet("GetUserAddress")]
        public IActionResult GetUserAddress()
        {
            var users = GetUserAddressList();

            var userAddressesViewModel = _mapper.Map<List<UserAddressViewModel>>(users);

            return Ok(userAddressesViewModel);
        }

        private List<User> GetUserList()
        {
            return new List<User>()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Bill",
                    LastName = "Lumbergh",
                    Email = "bill.lumbergh@initech.net",
                    Address = "Austin, Texas"
                },
                new()
                {
                    Id = 2,
                    FirstName = "Peter",
                    LastName = "Gibbons",
                    Email = "peter.gibbons@initech.net",
                    Address = "Austin, Texas"
                },
                new()
                {
                    Id = 3,
                    FirstName = "Michael",
                    LastName = "Bolton",
                    Email = "michael.bolton@initech.net",
                    Address = "Austin, Texas"
                },
                new()
                {
                    Id = 4,
                    FirstName = "Samir",
                    LastName = "Nagheenanajar",
                    Email = "samir.nagheenanajar@initech.net",
                    Address = "Austin, Texas"
                },
                new()
                {
                    Id = 4,
                    FirstName = "Milton",
                    LastName = "Waddams",
                    Email = "milton.waddams@initech.net",
                    Address = "Austin, Texas"
                }
            };
        }

        private List<UserAddress> GetUserAddressList()
        {
            return new List<UserAddress>()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Bill",
                    LastName = "Lumbergh",
                    Email = "bill.lumbergh@initech.net",
                    Address = new Address {City = "Austin", Country = "USA"}
                },
                new()
                {
                    Id = 2,
                    FirstName = "Peter",
                    LastName = "Gibbons",
                    Email = "peter.gibbons@initech.net",
                    Address = new Address {City = "Austin", Country = "USA"}
                },
                new()
                {
                    Id = 3,
                    FirstName = "Michael",
                    LastName = "Bolton",
                    Email = "michael.bolton@initech.net",
                    Address = new Address {City = "Austin", Country = "USA"}
                },
                new()
                {
                    Id = 4,
                    FirstName = "Samir",
                    LastName = "Nagheenanajar",
                    Email = "samir.nagheenanajar@initech.net",
                    Address = new Address {City = "Austin", Country = "USA"}
                },
                new()
                {
                    Id = 4,
                    FirstName = "Milton",
                    LastName = "Waddams",
                    Email = "milton.waddams@initech.net",
                    Address = new Address {City = "Austin", Country = "USA"}
                }
            };
        }
    }
}
