using Microsoft.EntityFrameworkCore;
using Project_API_ontwikkeling_LarsLauryssens.Data;
using Project_API_ontwikkeling_LarsLauryssens.Models;

namespace Project_API_ontwikkeling_LarsLauryssens.Services
{
    public class IndustryService : IIndustryService
    {

        private readonly ProjectDbContext _data;

        public IndustryService(ProjectDbContext data)
        {
            _data = data;
        }

        public async  Task<List<Industry>> GetAllIndustries()
        {
            var industries = await _data.Industries.ToListAsync();
            return industries;
        }

        public async Task<Industry> GetIndustryById(int id)
        {
            var industry = await _data.Industries.FirstOrDefaultAsync((x)  => x.Id == id);
            return industry;
        }
    }
}
