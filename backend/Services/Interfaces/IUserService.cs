/*
* IUserService
*
* This Defines methods for crud operations. 
*
* Implementations of this interface allow for 
* decoupling, testability, and flexability.
*/
using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}