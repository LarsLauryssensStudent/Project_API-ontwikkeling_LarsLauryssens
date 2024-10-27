using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API_ontwikkeling_LarsLauryssens.Services;

namespace Project_API_ontwikkeling_LarsLauryssens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetallCompanies()
        {
            var companies = await _service.GetAllCompanies();
            return Ok(companies);
        }


        [HttpGet("details/{id:int}")] 
        public async Task<ActionResult> GetCompanyById([FromRoute] int id)
        {
            var company = await _service.GetCompanyById(id);
            return Ok(company);
        }
    }
}
