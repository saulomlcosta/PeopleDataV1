using Microsoft.AspNetCore.Mvc;
using PeopleDataV1.Extensions;
using PeopleDataV1.Services.Interfaces;
using PeopleDataV1.ViewModels;
using PeopleDataV1.ViewModels.Users;

namespace PeopleDataV1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var users = await _userService.GetAllAsync();

                if (users is null)
                    return NoContent(); 

                return Ok(new ResultViewModel<IEnumerable<UserViewModel>>(users));
            }           
            catch
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);

                if (user is null)
                    return NotFound(new ResultViewModel<UserViewModel>("User not found"));

                return Ok(new ResultViewModel<UserViewModel>(user));
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(RegisterUserViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<UserViewModel>(ModelState.GetErrors()));

            try
            {
                var createUser = await _userService.AddAsync(model);
                return Created($"user/{createUser.Id}", new ResultViewModel<UserViewModel>(createUser));
            }
            catch
            {
                throw;
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<UserViewModel>(ModelState.GetErrors()));

            try
            {
                var updateUser = await _userService.UpdateAsync(model);
                return Ok(new ResultViewModel<UserViewModel>(updateUser));

            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                bool userDeleted = await _userService.DeleteAsync(id);

                if (!userDeleted)
                    return NotFound(new ResultViewModel<UserViewModel>("User not found"));

                return Ok(new ResultViewModel<dynamic>(new
                {
                   Message = "User Deleted Successfully!"
                }));
            }
            catch
            {
                throw;
            }
        }
    }
}
