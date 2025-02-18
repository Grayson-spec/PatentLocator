// Controllers/UsersController.cs
using Backend.Services;
using Backend.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using backend.Models;
using backend.Logging;
using backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILoggerManager _loggerManager;

        public UsersController(IUserService userService, ILoggerManager loggerManager)
        {
            _userService = userService;
            _loggerManager = loggerManager;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            _loggerManager.Logger.LogInformation("GetUsers endpoint called.");
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetUser(int id)
        {
            _loggerManager.Logger.LogInformation($"GetUser endpoint called with id {id}.");
            return await _userService.GetUserAsync(id);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _loggerManager.Logger.LogInformation("CreateUser endpoint called.");
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            _loggerManager.Logger.LogInformation($"UpdateUser endpoint called with id {id}.");
            if (id != user.Id)
            {
                _loggerManager.Logger.LogError($"Invalid user id {id}.");
                return BadRequest();
            }
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _loggerManager.Logger.LogInformation($"DeleteUser endpoint called with id {id}.");
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}