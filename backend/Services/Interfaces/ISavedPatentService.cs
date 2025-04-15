using backend.Models;

namespace backend.Services.Interfaces
{
    public interface ISavedPatentService
    {
        Task<IEnumerable<SavedPatent>> GetSavedPatentsByUserIdAsync(int userId);
        Task AddSavedPatentAsync(SavedPatent savedPatent);
        Task DeleteSavedPatentAsync(int id);
    }
}
