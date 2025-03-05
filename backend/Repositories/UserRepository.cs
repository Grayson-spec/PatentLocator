/*
* UserRepository
*
* This Repository encapsulates data access logic, which provides
* a layer of abstraction between the service and the database.
*
* This repository uses Entity Framework Core to interact with the AppDbContext 
* which allows for all database operations to be automated.
*/
using backend.Models;
using backend.Data;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using backend.Infrastructure;

namespace backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(int pageIndex = 0, int pageSize = 10)
        {
            try
            {
                return await _context.Users
                                     .Skip(pageIndex * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching users from the database.");
                throw new DatabaseException("An error occurred while fetching users.");
            }
        }

        public async Task<User?> GetUserAsync(int id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching user with ID {id}.");
                throw new DatabaseException($"An error occurred while fetching the user with ID {id}.");
            }
        }

        public async Task CreateUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new user.");
                throw new DatabaseException("An error occurred while creating the user.");
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating user with ID {user.Id}.");
                throw new DatabaseException($"An error occurred while updating user with ID {user.Id}.");
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    throw new DatabaseException($"User with ID {id} not found.");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting user with ID {id}.");
                throw new DatabaseException($"An error occurred while deleting user with ID {id}.");
            }
        }
    }
}
