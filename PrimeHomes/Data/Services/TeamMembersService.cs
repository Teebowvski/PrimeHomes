using Microsoft.EntityFrameworkCore;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public class TeamMembersService : ITeamMembersService
    {
        private readonly ApplicationDbContext _context;
        public TeamMembersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TeamMembers teamMembers)
        {
            var data = _context.TeamMembers.Add(teamMembers);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.TeamMembers.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TeamMembers>> GetAllAsync()
        {
            var data = await _context.TeamMembers.ToListAsync();
            return data;
        }

        public async Task<TeamMembers> GetByIdAsync(int id)
        {
            var TeamMembers = await _context.TeamMembers.FirstOrDefaultAsync(m => m.Id == id);
            return TeamMembers;
        }

        public IEnumerable<TeamMembers> TeamMembers() => _context.TeamMembers;


        public async Task<TeamMembers> UpdateAsync(int id, TeamMembers newTeamMembers)
        {
            var data = _context.TeamMembers.Update(newTeamMembers);
            await _context.SaveChangesAsync();
            return newTeamMembers;

        }
    }
}
