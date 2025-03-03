/*
* PatentRepository
*
* This Repository encapsulates data access logic, which provides
* a layer of abstraction between the service and the database.
*
* This repository uses Entity Framework Core to interact with the AppDbContext 
* which allows for all database operations to be automated.
*/

using backend.Models;
using backend.Data;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PatentRepository : IPatentRepository
    {
        private readonly ApplicationDbContext _context;

        public PatentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patent>> GetPatentsAsync()
        {
            return await _context.Patents.ToListAsync();
        }

        public async Task<Patent?> GetPatentAsync(int id)
        {
            return await _context.Patents.FindAsync(id);
        }

        public async Task CreatePatentAsync(Patent patent)
        {
            _context.Patents.Add(patent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatentAsync(Patent patent)
        {
            _context.Patents.Update(patent);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatentAsync(int id)
        {
            var patent = await _context.Patents.FindAsync(id);
            if (patent != null)
            {
                _context.Patents.Remove(patent);
                await _context.SaveChangesAsync();
            }
        }
    }
}