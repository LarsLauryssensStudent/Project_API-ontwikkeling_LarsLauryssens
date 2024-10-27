using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Project_API_ontwikkeling_LarsLauryssens.Data;
using Project_API_ontwikkeling_LarsLauryssens.Models;

namespace Project_API_ontwikkeling_LarsLauryssens.Services
{
    public class StockService : IStockService
    {
        private readonly ProjectDbContext _dbContext;

        public StockService(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Stock>> GetAllStocks()
        {
            var stocks = await _dbContext.Stocks.ToListAsync();
            return stocks;
        }

        public async Task<Stock> GetStockById(int id)
        {
            var stock = await _dbContext.Stocks.FirstOrDefaultAsync((x) => x.Id == id);
            return stock;
        }
    }
}
