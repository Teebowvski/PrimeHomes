using Microsoft.EntityFrameworkCore;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public class BedroomService : IBedroomService
    {
        private readonly ApplicationDbContext _context;
        public BedroomService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Bedrooms Bedrooms)
        {
            var data = _context.Bedrooms.Add(Bedrooms);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.Bedrooms.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bedrooms>> GetAllAsync()
        {
            var data = await _context.Bedrooms.ToListAsync();
            return data;
        }

        public async Task<Bedrooms> GetByIdAsync(int id)
        {
            var Bedrooms = await _context.Bedrooms.FirstOrDefaultAsync(m => m.Id == id);
            return Bedrooms;
        }

        public IEnumerable<Bedrooms> Bedrooms() => _context.Bedrooms;


        public async Task<Bedrooms> UpdateAsync(int id, Bedrooms newBedrooms)
        {
            var data = _context.Bedrooms.Update(newBedrooms);
            await _context.SaveChangesAsync();
            return newBedrooms;

        }
    }
}
