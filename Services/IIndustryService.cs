using Project_API_ontwikkeling_LarsLauryssens.Models;

namespace Project_API_ontwikkeling_LarsLauryssens.Services
{
    public interface IIndustryService
    {
        public Task<List<Industry>> GetAllIndustries();
        public Task<Industry> GetIndustryById(int id);

    }
}
