using backend.Data;
using backend.Models;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class SavedPatentRepository : ISavedPatentRepository
    {
        private readonly ApplicationDbContext _context;

        public SavedPatentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SavedPatent>> GetSavedPatentsByUserIdAsync(int userId)
        {
            return await _context.SavedPatents
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task AddSavedPatentAsync(SavedPatent savedPatent)
        {
            _context.SavedPatents.Add(savedPatent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSavedPatentAsync(int id)
        {
            var savedPatent = await _context.SavedPatents.FindAsync(id);
            if (savedPatent != null)
            {
                _context.SavedPatents.Remove(savedPatent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
