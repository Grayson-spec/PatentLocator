using backend.Services;
using backend.Services.Interfaces;
using backend.Models;
using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILoggerManager _loggerManager;
        private readonly ISavedPatentService _savedPatentService;

        public UsersController(IUserService userService, ILoggerManager loggerManager, ISavedPatentService savedPatentService)
        {
            _userService = userService;
            _loggerManager = loggerManager;
            _savedPatentService = savedPatentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            Console.WriteLine("🔥 Signup endpoint hit");

            try
            {
                var createdUser = await _userService.CreateUserAsync(user);
                return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔥 SIGNUP EXCEPTION: {ex.Message}");
                _loggerManager.Logger.LogError($"Signup error: {ex.Message}");
                return StatusCode(500, "Server error during signup: " + ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] User credentials)
        {
            Console.WriteLine("🔥 Login endpoint hit");

            try
            {
                _loggerManager.Logger.LogInformation($"LOGIN ATTEMPT → Username: {credentials.Username}, Password: {credentials.Password}");

                var user = await _userService.AuthenticateAsync(credentials.Username, credentials.Password);
                if (user == null)
                {
                    _loggerManager.Logger.LogError("❌ No matching user found.");
                    return Unauthorized("Invalid credentials");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔥 LOGIN EXCEPTION: {ex.Message}");
                _loggerManager.Logger.LogError($"Login error: {ex.Message}");
                return StatusCode(500, "Server error during login: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("saved/{userId}")]
        public async Task<ActionResult<IEnumerable<SavedPatent>>> GetSavedPatents(int userId)
        {
            var saved = await _savedPatentService.GetSavedPatentsByUserIdAsync(userId);
            return Ok(saved);
        }

        [HttpPost("saved")]
        public async Task<ActionResult> SavePatent([FromBody] SavedPatent savedPatent)
        {
            await _savedPatentService.AddSavedPatentAsync(savedPatent);
            return Ok();
        }

        [HttpDelete("saved/{id}")]
        public async Task<ActionResult> DeleteSavedPatent(int id)
        {
            await _savedPatentService.DeleteSavedPatentAsync(id);
            return NoContent();
        }
    }
}
