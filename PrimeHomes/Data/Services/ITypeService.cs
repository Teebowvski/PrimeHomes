
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Type = PrimeHomes.Models.Type;

namespace PrimeHomes.Data.Services
{
    public interface ITypeService
    {
        Task<IEnumerable<Models.Type>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Models.Type type);

        Task<Type> GetByIdAsync(int id);
        Task<Type> UpdateAsync(int id, Models.Type newType);
        IEnumerable<Type> Type();
    }
}
