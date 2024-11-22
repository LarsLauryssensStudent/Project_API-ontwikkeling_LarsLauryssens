using Project_API_ontwikkeling_LarsLauryssens.Models;

namespace Project_API_ontwikkeling_LarsLauryssens.Services
{
    public interface IStockService
    {
        public Task<List<Stock>> GetAllStocks();

        public Task<Stock> GetStockById(int id);

        public Task<Stock> AddStock(Stock stock);

        public Task<Stock> UpdateStock(Stock stock);

        public Task DeleteStock(int id);
    }
}
