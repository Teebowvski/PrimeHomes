using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public interface ITeamMembersService
    {
        Task<IEnumerable<TeamMembers>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(TeamMembers teamMembers);

        Task<TeamMembers> GetByIdAsync(int id);
        Task<TeamMembers> UpdateAsync(int id, TeamMembers newTeamMembers);
        IEnumerable<TeamMembers> TeamMembers();
    }
}
