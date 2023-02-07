using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        Task<IEnumerable<Order>> GetAllAsync();
        
    }
}
