using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories.Interfaces
{
    public interface ISavedPatentRepository
    {
        Task<IEnumerable<SavedPatent>> GetSavedPatentsByUserIdAsync(int userId);
        Task AddSavedPatentAsync(SavedPatent savedPatent);
        Task DeleteSavedPatentAsync(int id);
    }
}
