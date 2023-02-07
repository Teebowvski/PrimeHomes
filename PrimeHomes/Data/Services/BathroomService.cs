using Microsoft.EntityFrameworkCore;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public class BathroomsService: IBathroomService
    {
        private readonly ApplicationDbContext _context;
        public BathroomsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Bathrooms Bathrooms)
        {
            var data = _context.Bathrooms.Add(Bathrooms);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.Bathrooms.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bathrooms>> GetAllAsync()
        {
            var data = await _context.Bathrooms.ToListAsync();
            return data;
        }

        public async Task<Bathrooms> GetByIdAsync(int id)
        {
            var Bathrooms = await _context.Bathrooms.FirstOrDefaultAsync(m => m.Id == id);
            return Bathrooms;
        }

        public IEnumerable<Bathrooms> Bathrooms() => _context.Bathrooms;


        public async Task<Bathrooms> UpdateAsync(int id, Bathrooms newBathrooms)
        {
            var data = _context.Bathrooms.Update(newBathrooms);
            await _context.SaveChangesAsync();
            return newBathrooms;

        }

        public IEnumerable<Bathrooms> Bathroom() => _context.Bathrooms;
        
    }
}
