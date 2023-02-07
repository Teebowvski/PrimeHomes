using Microsoft.EntityFrameworkCore;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public class StatusService:IStatusService
    {
        private readonly ApplicationDbContext _context;
        public StatusService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Status status)
        {
            var data = _context.Status.Add(status);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.Status.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            var data = await _context.Status.ToListAsync();
            return data;
        }

        public async Task<Status> GetByIdAsync(int id)
        {
            var Status = await _context.Status.FirstOrDefaultAsync(m => m.Id == id);
            return Status;
        }

        public IEnumerable<Status> Status() => _context.Status;


        public async Task<Status> UpdateAsync(int id, Status newStatus)
        {
            var data = _context.Status.Update(newStatus);
            await _context.SaveChangesAsync();
            return newStatus;

        }
    }
}
