/*
*
* UserController
*
* This handles HTTP requests for managing the data related to the user. 
* This currently provides CRUD operations to the database.
*
* This controller class utilizes respective Service and Repository layers. 
* The UserService handles Business Logic.
* The UserRepository handles data access through Entity Framework Core.
*
*/
using backend.Services;
using backend.Data;
using backend.Services.Interfaces;
using backend.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using backend.Interfaces;
using backend.Infrastructure;
using backend.Repositories;
using backend.Repositories.Interfaces;
using backend.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IPagination<User>>> GetUsers(int pageIndex = 0, int pageSize = 10)
        {
            _loggerManager.Logger.LogInformation("GetUsers endpoint called.");

            // Fetch paginated users from the service
            var usersResult = await _userService.GetUsersAsync(pageIndex, pageSize);
            
            // Return the paginated result to the client (including metadata)
            return Ok(usersResult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUserAsync(id);
                if(user == null)
                {
                    return NotFound("User not found.");
                }
                return Ok(user);
            }
            catch (ServiceException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                _loggerManager.Logger.LogError("Invalid user model");
                return BadRequest(ModelState);
            }

            _loggerManager.Logger.LogInformation("CreateUser endpoint called.");
            await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                _loggerManager.Logger.LogError($"Invalid user id: {id}");
                return BadRequest("Invalid user id");
            }

            if (!ModelState.IsValid)
            {
                _loggerManager.Logger.LogError("Invalid user model");
                return BadRequest(ModelState);
            }

            _loggerManager.Logger.LogInformation($"UpdateUser endpoint called with id {id}.");
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id < 1)
            {
                _loggerManager.Logger.LogError($"Invalid user id: {id}");
                return BadRequest("Invalid user id");
            }

            _loggerManager.Logger.LogInformation($"DeleteUser endpoint called with id {id}.");
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}