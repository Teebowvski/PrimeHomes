using Microsoft.EntityFrameworkCore;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public class TypeService:ITypeService
    {
        private readonly ApplicationDbContext _context;
        public TypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Models.Type type)
        {
            var data = _context.Types.Add(type);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.Types.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Type>> GetAllAsync()
        {
            var data = await _context.Types.ToListAsync();
            return data;
        }

        public async Task<Models.Type> GetByIdAsync(int id)
        {
            var Type = await _context.Types.FirstOrDefaultAsync(m => m.Id == id);
            return Type;
        }

        public IEnumerable<Models.Type> Type() => _context.Types;


        public async Task<Models.Type> UpdateAsync(int id, Models.Type newType)
        {
            var data = _context.Types.Update(newType);
            await _context.SaveChangesAsync();
            return newType;

        }
    }
}
