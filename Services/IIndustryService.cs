using Project_API_ontwikkeling_LarsLauryssens.Models;

namespace Project_API_ontwikkeling_LarsLauryssens.Services
{
    public interface IIndustryService
    {
        public Task<List<Industry>> GetAllIndustries();
        public Task<Industry> GetIndustryById(int id);

        public Task<Industry> AddIndustry(Industry industry);

        public Task<Industry> UpdateIndustry(Industry industry);

        public Task DeleteIndustry(int id);

    }
}
