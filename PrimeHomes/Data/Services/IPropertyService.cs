
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<Property>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync (Property property);

        Task<Property> GetByIdAsync(int id);
        Task<Property> UpdateAsync(int id,Property newProperty);
        IEnumerable<Property> Property();

    }
}
