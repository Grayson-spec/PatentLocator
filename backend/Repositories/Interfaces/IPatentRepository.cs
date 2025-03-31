/*
* IPatentRepository
*
* This specifies methods for CRUD operations and search functionality.
*
* Implementations of this interface allow for 
* decoupling, testability, and flexibility.
*/
using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories.Interfaces
{
    public interface IPatentRepository
    {
        Task<IEnumerable<Patent>> GetPatentsAsync();
        Task<Patent?> GetPatentAsync(int id);
        Task CreatePatentAsync(Patent patent);
        Task UpdatePatentAsync(Patent patent);
        Task DeletePatentAsync(int id);

        // New search method
        Task<IEnumerable<Patent>> SearchPatentsAsync(string query);
    }
}
