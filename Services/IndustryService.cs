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
            try
            {
                var industry = await _data.Industries.FirstOrDefaultAsync((x) => x.Id == id);
                if (industry == null)
                {
                    throw new Exception("Geen industry met " + id + " gevonden");
                }

                return industry;
            } 
            catch (Exception ex)
            {
                throw new Exception("Er ging iets fout bij het ophalen vn de industry: " + ex.Message, ex);
            }
        }

        public async Task<Industry> AddIndustry(Industry industry)
        {
            try
            {
                await _data.Industries.AddAsync(industry);
                await _data.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Er ging hier iets fout bij AddIndustry " + ex.Message, ex);
            }
            return industry;
        }

        public async Task<Industry> UpdateIndustry(Industry industry)
        {
            try
            {
                var oldIndustry = await _data.Industries.FirstOrDefaultAsync(a => a.Id == industry.Id);
                if (oldIndustry == null)
                {
                    throw new Exception("Geen industry met Id " + industry.Id + " gevonden");
                }

                oldIndustry.Name = industry.Name;
                oldIndustry.Companies = industry.Companies;

                _data.Industries.Update(oldIndustry);
                await _data.SaveChangesAsync();

                return oldIndustry;
            }
            catch (Exception ex)
            {
                throw new Exception("Er ging iets fout bij het updaten van idustry: " + ex.Message, ex );
            }
        }

        public async Task DeleteIndustry(int id)
        {
            try
            {
                var result = await _data.Industries.FirstOrDefaultAsync((a) => a.Id == id);
                if (result == null)
                {
                    throw new Exception("Geen industry met dit id " + id + " gevonden");
                }
                _data.Industries.Remove(result);
                await _data.SaveChangesAsync();
            } 
            catch (Exception ex)
            {
                throw new Exception("Er ging iets mis bij delete industry " + ex.Message, ex);
            }
        }
  
    }
}
