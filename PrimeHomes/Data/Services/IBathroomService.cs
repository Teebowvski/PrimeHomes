using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public interface IBathroomService
    {
        Task<IEnumerable<Bathrooms>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Bathrooms bathrooms);

        Task<Bathrooms> GetByIdAsync(int id);
        Task<Bathrooms> UpdateAsync(int id, Bathrooms newBathrooms);
        IEnumerable<Bathrooms> Bathroom();
    }
}
