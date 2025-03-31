/*
* PatentService
*
* This encapsulates business logic for managing the user, which provides abstraction
* between the controller and repository.
*
* This service uses the IPatentRepository to interact with the data, allowing 
* for decoupling and testability.
*/
using backend.Models;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    public class PatentService : IPatentService
    {
        private readonly IPatentRepository _patentRepository;

        public PatentService(IPatentRepository patentRepository)
        {
            _patentRepository = patentRepository;
        }

        public async Task<IEnumerable<Patent>> GetPatentsAsync()
        {
            return await _patentRepository.GetPatentsAsync();
        }

        public async Task<Patent?> GetPatentAsync(int id)
        {
            return await _patentRepository.GetPatentAsync(id);
        }

        public async Task CreatePatentAsync(Patent patent)
        {
            await _patentRepository.CreatePatentAsync(patent);
        }

        public async Task UpdatePatentAsync(Patent patent)
        {
            await _patentRepository.UpdatePatentAsync(patent);
        }

        public async Task DeletePatentAsync(int id)
        {
            await _patentRepository.DeletePatentAsync(id);
        }

        // ✅ NEW: Implements the interface search method
        public async Task<IEnumerable<Patent>> SearchPatentsAsync(string query)
        {
            return await _patentRepository.SearchPatentsAsync(query);
        }
    }
}
