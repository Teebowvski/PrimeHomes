using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public interface IAreaService
    {
        Task<IEnumerable<Area>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Area area );

        Task<Area> GetByIdAsync(int id);
        Task<Area> UpdateAsync(int id, Area newArea);
        IEnumerable<Area> Area();
    }
}
