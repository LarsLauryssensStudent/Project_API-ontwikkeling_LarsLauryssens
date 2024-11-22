using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Project_API_ontwikkeling_LarsLauryssens.Data;
using Project_API_ontwikkeling_LarsLauryssens.Models;

namespace Project_API_ontwikkeling_LarsLauryssens.Services
{
    public class StockService : IStockService
    {
        private readonly ProjectDbContext _data;

        public StockService(ProjectDbContext dbContext)
        {
            _data = dbContext;
        }

        public async Task<List<Stock>> GetAllStocks()
        {
            var stocks = await _data.Stocks.ToListAsync();
            return stocks;
        }

        public async Task<Stock> GetStockById(int id)
        {
            try
            {
                var stock = await _data.Stocks.FirstOrDefaultAsync((x) => x.Id == id);
                if (stock == null)
                {
                    throw new Exception("Geen stock met id: " + id + " gevonden");
                }
                return stock;
            }
            catch (Exception ex)
            {
                throw new Exception("Er ging iets mis in stockservice getstock " + ex.Message, ex);
            }
            
        }

        public async Task<Stock> AddStock(Stock stock)
        {
            try
            {
                await _data.Stocks.AddAsync(stock);
                await _data.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("er ging iets fout bij de addstock: " + ex.Message, ex);
            }
            return stock;
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            try
            {
                var oldStock = await _data.Stocks.FirstOrDefaultAsync(a => a.Id == stock.Id);
                if (oldStock == null)
                {
                    throw new Exception("geen stock gevonden met dit id " + stock.Id);
                }
                var company = await _data.Companies.FirstOrDefaultAsync(a => a.Id == stock.CompanyId);
                if (company == null)
                {
                    throw new Exception("geen geldige companyId");
                }
                oldStock.Name = stock.Name;
                oldStock.CompanyId = stock.CompanyId;
                await _data.Stocks.AddAsync(stock);
                await _data.SaveChangesAsync();

                return oldStock;
            } 
            catch (Exception ex)
            {
                throw new Exception("er ging iets mis met updatestock: " + ex.Message, ex);
            }
        }

        public async Task DeleteStock(int id)
        {
            try
            {
                var result = await _data.Stocks.FirstOrDefaultAsync(a => a.Id == id);
                if (result == null)
                {
                    throw new Exception("Geen stock met dit id gevonden: " + id);
                }
                _data.Stocks.Remove(result);
                await _data.SaveChangesAsync();
            } 
            catch (Exception ex)
            {
                throw new Exception("Er ging iets fout in deletestock: " + ex.Message, ex);
            }
        }
     
    }
}
