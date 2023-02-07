using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public interface IBedroomService
    {
        Task<IEnumerable<Bedrooms>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Bedrooms bedrooms);

        Task<Bedrooms> GetByIdAsync(int id);
        Task<Bedrooms> UpdateAsync(int id, Bedrooms newBedrooms);
        IEnumerable<Bedrooms> Bedrooms();
    }
}
