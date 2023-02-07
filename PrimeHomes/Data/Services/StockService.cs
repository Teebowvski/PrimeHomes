using Microsoft.EntityFrameworkCore;
using PrimeHomes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeHomes.Data.Services
{
    public class StockService:IStockService
    {
        private readonly ApplicationDbContext _context;
        public StockService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Stock stock)
        {
            var data = _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = _context.Stocks.FirstOrDefault(x => x.Id == id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            var data = await _context.Stocks.ToListAsync();
            return data;
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            var Stock = await _context.Stocks.FirstOrDefaultAsync(m => m.Id == id);
            return Stock;
        }

        public IEnumerable<Stock> Stock() => _context.Stocks;


        public async Task<Stock> UpdateAsync(int id, Stock newStock)
        {
            var data = _context.Stocks.Update(newStock);
            await _context.SaveChangesAsync();
            return newStock;

        }
    }
}
