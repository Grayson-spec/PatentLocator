/*
* IPatentRepository
*
* This specifies methods for crud operations. 
*
* Implementations of this interface allow for 
* decoupling, testability, and flexability.
*/
using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public interface IPatentRepository
    {
        Task<IEnumerable<Patent>> GetPatentsAsync();
        Task<Patent?> GetPatentAsync(int id);
        Task CreatePatentAsync(Patent patent);
        Task UpdatePatentAsync(Patent patent);
        Task DeletePatentAsync(int id);
    }
}