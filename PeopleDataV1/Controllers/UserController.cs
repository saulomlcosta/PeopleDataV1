using Microsoft.AspNetCore.Mvc;
using PeopleDataV1.Entities;
using PeopleDataV1.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeopleDataV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseService<User> _userService;

        public UserController(IBaseService<User> userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id}")]
        public User GetById(Guid id)
        {
            return _userService.GetById(id);
        }

        [HttpPost]
        public User AddUser(User model)
        {
            return _userService.Add(model);
        }

        [HttpPut()]
        public User Put(User model)
        {
            return _userService.Update(model);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return _userService.Delete(id);
        }
    }
}
