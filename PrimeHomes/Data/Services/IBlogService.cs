using PrimeHomes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Blog blog);

        Task<Blog> GetByIdAsync(int id);
        Task<Blog> UpdateAsync(int id, Blog newBlog);
        IEnumerable<Blog> Blog();
    }
}
