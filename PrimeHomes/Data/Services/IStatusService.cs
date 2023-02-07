using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public interface IStatusService
    {
        Task<IEnumerable<Status>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Status Status);

        Task<Status> GetByIdAsync(int id);
        Task<Status> UpdateAsync(int id, Status newStatus);
        IEnumerable<Status> Status();
    }
}
