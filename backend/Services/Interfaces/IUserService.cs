using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User?> AuthenticateAsync(string username, string password);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
