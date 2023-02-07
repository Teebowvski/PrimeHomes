using Microsoft.EntityFrameworkCore;
using PrimeHomes.Data;
using PrimeHomes.Data.Services;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Service
{
    public class AreaService:IAreaService
    {
        private readonly ApplicationDbContext _context;
        public AreaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Area Area)
        {
            var data = _context.Areas.Add(Area);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.Areas.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            var data = await _context.Areas.ToListAsync();
            return data;
        }

        public async Task<Area> GetByIdAsync(int id)
        {
            var Area = await _context.Areas.FirstOrDefaultAsync(m => m.Id == id);
            return Area;
        }

        public IEnumerable<Area> Area() => _context.Areas;


        public async Task<Area> UpdateAsync(int id, Area newArea)
        {
            var data = _context.Areas.Update(newArea);
            await _context.SaveChangesAsync();
            return newArea;

        }
    }
}

