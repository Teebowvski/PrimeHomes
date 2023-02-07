using Microsoft.EntityFrameworkCore;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public class FeaturesService : IFeaturesService
    {
        private readonly ApplicationDbContext _context;
        public FeaturesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Features Features)
        {
            var data = _context.Features.Add(Features);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.Features.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Features>> GetAllAsync()
        {
            var data = await _context.Features.ToListAsync();
            return data;
        }

        public async Task<Features> GetByIdAsync(int id)
        {
            var Features = await _context.Features.FirstOrDefaultAsync(m => m.Id == id);
            return Features;
        }

        public IEnumerable<Features> Features() => _context.Features.Include(c=>c.Property);


        public async Task<Features> UpdateAsync(int id, Features newFeatures)
        {
            var data = _context.Features.Update(newFeatures);
            await _context.SaveChangesAsync();
            return newFeatures;

        }
    }
}
