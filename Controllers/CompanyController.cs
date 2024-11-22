using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API_ontwikkeling_LarsLauryssens.Models;
using Project_API_ontwikkeling_LarsLauryssens.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project_API_ontwikkeling_LarsLauryssens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService service , ILogger<CompanyController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> AAGetallCompanies()
        {
            var companies = await _service.GetAllCompanies();
            return Ok(companies);
        }


        [HttpGet("details/{id:int}")] 
        public async Task<ActionResult> AAGetCompanyById([FromRoute] int id)
        {
            try
            {
                var company = await _service.GetCompanyById(id);
                return Ok(company);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddCompanyToDataList([FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geen geldige data ingegeven");
            }
            try
            {
                await _service.AddCompany(company);
                return CreatedAtAction(nameof(AAGetCompanyById), new { id = company.Id }, company);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest("CompanyRouter " + ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateCompanyInDataBase([FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geen geldige data ingegeven");
            }
            try
            {
                var result = await _service.UpdateCompany(company);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest("CompanyRouter " + ex.Message);
            }
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteCompanyFromDatabase([FromRoute] int id)
        {
            try
            {
                await _service.DeleteCompany(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest("CompanyRouter " + ex.Message);
            }
        }
    }
}
