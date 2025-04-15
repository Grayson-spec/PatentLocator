using backend.Models;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class SavedPatentService : ISavedPatentService
    {
        private readonly ISavedPatentRepository _savedPatentRepository;

        public SavedPatentService(ISavedPatentRepository savedPatentRepository)
        {
            _savedPatentRepository = savedPatentRepository;
        }

        public async Task<IEnumerable<SavedPatent>> GetSavedPatentsByUserIdAsync(int userId)
        {
            return await _savedPatentRepository.GetSavedPatentsByUserIdAsync(userId);
        }

        public async Task AddSavedPatentAsync(SavedPatent savedPatent)
        {
            await _savedPatentRepository.AddSavedPatentAsync(savedPatent);
        }

        public async Task DeleteSavedPatentAsync(int id)
        {
            await _savedPatentRepository.DeleteSavedPatentAsync(id);
        }
    }
}
