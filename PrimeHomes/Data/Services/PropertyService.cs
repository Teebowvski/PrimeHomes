using Microsoft.EntityFrameworkCore;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _context;
        public PropertyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Property property)
        {
            var data = _context.Properties.Add(property);
          await  _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.Properties.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            var data = await _context.Properties.Include(c => c.Area).Include(c => c.Bathrooms).Include(c => c.Bedrooms).Include(c => c.Features).Include(c => c.Status).Include(c => c.Stock).Include(c => c.Type).ToListAsync();
            return data;
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            var property = await _context.Properties
               .Include(c => c.Area)
               .Include(c => c.Bathrooms)
               .Include(c => c.Bedrooms)
               .Include(c => c.Features)
               .Include(c => c.Status)
               .Include(c => c.Stock)
               .Include(c => c.Type)
               .FirstOrDefaultAsync(m => m.Id == id);
            return property;
        }

        public IEnumerable<Property> Property() => _context.Properties.Include(c => c.Area)
               .Include(c => c.Bathrooms)
               .Include(c => c.Bedrooms)
               .Include(c => c.Features)
               .Include(c => c.Status)
               .Include(c => c.Stock)
               .Include(c => c.Type);
        

        public async Task<Property> UpdateAsync(int id, Property newProperty)
        {
            var data =  _context.Properties.Update(newProperty);
            await _context.SaveChangesAsync();
            return newProperty;

        }
    }
}
