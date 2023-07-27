using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PeopleDataV1.Extensions;
using PeopleDataV1.Services.Interfaces;
using PeopleDataV1.ViewModels;
using PeopleDataV1.ViewModels.Users;

namespace PeopleDataV1.Controllers
{
    [Route("api/[controller]")]
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
                {
                    return NoContent(); 
                }

                return Ok(new ResultViewModel<IEnumerable<UserViewModel>>(users));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X08 - DB Update failed: " + ex.Message));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X09 - SQL Exception: " + ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X10 - Server failed: " + ex.Message));
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
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X08 - DB Update failed: " + ex.Message));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X09 - SQL Exception: " + ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X10 - Server failed: " + ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<UserViewModel>(ModelState.GetErrors()));
            try
            {
                var createUser = await _userService.AddAsync(model);
                return Created($"user/{createUser.Id}", new ResultViewModel<UserViewModel>(createUser));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X08 - DB Update failed: " + ex.Message));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X09 - SQL Exception: " + ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X10 - Server failed: " + ex.Message));
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put(UpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<UserViewModel>(ModelState.GetErrors()));

            try
            {
                var updateUser = await _userService.UpdateAsync(model);
                return Ok(new ResultViewModel<UserViewModel>(updateUser));

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X08 - DB Update failed: " + ex.Message));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X09 - SQL Exception: " + ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X10 - Server failed: " + ex.Message));
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

                return Ok(new ResultViewModel<UserViewModel>("User deleted"));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X08 - DB Update failed: " + ex.Message));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X09 - SQL Exception: " + ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<UserViewModel>("05X10 - Server failed: " + ex.Message));
            }
        }
    }
}
