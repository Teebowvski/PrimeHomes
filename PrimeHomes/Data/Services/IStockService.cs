using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Stock stock);

        Task<Stock> GetByIdAsync(int id);
        Task<Stock> UpdateAsync(int id, Stock newStock);
        IEnumerable<Stock> Stock();
    }
}
