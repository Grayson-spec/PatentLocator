using backend.Models;
using backend.Data;
using backend.Repositories.Interfaces;
using backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
        public class Pagination<T> : IPagination<T>
        {
            public IEnumerable<T> Items { get; }
            public int PageIndex { get; }
            public int PageSize { get; }
            public int TotalCount { get; }
            public int TotalPages { get; }

            public Pagination(IEnumerable<T> items, int pageIndex, int pageSize, int totalCount)
            {
                Items = items;
                PageIndex = pageIndex;
                PageSize = pageSize;
                TotalCount = totalCount;
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            }
        }

        public async Task<IPagination<User>> GetUsersAsync(int pageIndex = 0, int pageSize = 10)
        {
            try
            {
                var totalCount = await _context.Users.CountAsync();
                var users = await _context.Users
                                           .Skip(pageIndex * pageSize)
                                           .Take(pageSize)
                                           .ToListAsync();
                return new Pagination<User>(users, pageIndex, pageSize, totalCount);
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
