using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public interface IFeaturesService
    {
        Task<IEnumerable<Features>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Features Features);

        Task<Features> GetByIdAsync(int id);
        Task<Features> UpdateAsync(int id, Features newFeatures);
        IEnumerable<Features> Features();
    }
}
