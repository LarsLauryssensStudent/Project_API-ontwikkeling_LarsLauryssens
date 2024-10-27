using Project_API_ontwikkeling_LarsLauryssens.Models;

namespace Project_API_ontwikkeling_LarsLauryssens.Services
{
    public interface ICompanyService
    {
        public Task<List<Company>> GetAllCompanies();

        public Task<Company> GetCompanyById(int id);
    }
}
