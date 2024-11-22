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
            if (company == null)
            {
                throw new Exception("Geen company met dit id gevonden");
            }
            return company;
        }

        public async Task<Company?> AddCompany(Company company)
        {
            try
            {
                // Check if Industry exists
                var industryExists = await _data.Industries.AnyAsync(i => i.Id == company.IndustryId);
                if (!industryExists)
                {
                    throw new Exception("Invalid Industry ID");
                }

                // Add the company to the database
                await _data.AddAsync(company);
                await _data.SaveChangesAsync();

                return company;
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                throw new Exception("An error occurred while saving the company.", ex);
            }
        }


        public async Task<Company> UpdateCompany(Company company)
        {
            try
            {
                var oldCompany = await _data.Companies.FirstOrDefaultAsync(a => a.Id == company.Id);
                if (oldCompany == null)
                {
                    throw new Exception("Geen geldige update");
                }

                oldCompany.Name = company.Name;
                oldCompany.City = company.City;
                oldCompany.Country = company.Country;
                oldCompany.MarketCap = company.MarketCap;
                oldCompany.IndustryId = company.IndustryId;

                _data.Companies.Update(oldCompany);
                await _data.SaveChangesAsync();

                return oldCompany;
            }
            catch (Exception ex)
            {
                throw new Exception("Er ging iets mis met het updaten" + ex.Message, ex);
            }
        }

        public async Task DeleteCompany(int id)
        {
            try
            {
                var result = await GetCompanyById(id);
                if (result == null)
                {
                    throw new Exception("Geen geldige Id meegegeven");
                }
                _data.Companies.Remove(result);
                await _data.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Er ging iets mis met t verwijderen van een bedrijf " + ex.Message, ex);
            }
        }

    }
}
