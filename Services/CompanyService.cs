using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Project_API_ontwikkeling_LarsLauryssens.Data;
using Project_API_ontwikkeling_LarsLauryssens.Models;

namespace Project_API_ontwikkeling_LarsLauryssens.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ProjectDbContext _data;

        public CompanyService(ProjectDbContext data)
        {
            _data = data;
        }
        public async Task<List<Company>> GetAllCompanies()
        {
            var companies = await _data.Companies.ToListAsync();
            return companies;
        }

        public async Task<Company> GetCompanyById(int id)
        {
            var company = await _data.Companies.FirstOrDefaultAsync(x => x.Id == id);
            
            return company;
        }
    }
}
