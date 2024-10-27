using Project_API_ontwikkeling_LarsLauryssens.Models;

namespace Project_API_ontwikkeling_LarsLauryssens.Services
{
    public interface IStockService
    {
        public Task<List<Stock>> GetAllStocks();

        public Task<Stock> GetStockById(int id);
    }
}
