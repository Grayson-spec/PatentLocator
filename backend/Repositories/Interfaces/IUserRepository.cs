using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IPagination<User>> GetUsersAsync(int pageIndex = 0, int pageSize = 10);
        Task<User?> GetUserAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }

    public interface IPagination<T>
    {
        IEnumerable<T> Items { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
    }
}
