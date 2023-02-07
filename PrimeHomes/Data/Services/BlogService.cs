using Microsoft.EntityFrameworkCore;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;
        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Blog blog)
        {
            var data = _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.Blogs.FirstOrDefault(x => x.id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            var data = await _context.Blogs.ToListAsync();
            return data;
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            var Blog = await _context.Blogs.FirstOrDefaultAsync(m => m.id == id);
            return Blog;
        }

        public IEnumerable<Blog> Blog() => _context.Blogs.OrderBy(c=>c.DateCreated);


        public async Task<Blog> UpdateAsync(int id, Blog newBlog)
        {
            var data = _context.Blogs.Update(newBlog);
            await _context.SaveChangesAsync();
            return newBlog;

        }
    }
}
