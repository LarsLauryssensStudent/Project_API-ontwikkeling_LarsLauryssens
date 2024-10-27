using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API_ontwikkeling_LarsLauryssens.Services;

namespace Project_API_ontwikkeling_LarsLauryssens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        private readonly IIndustryService _service;

        public IndustryController(IIndustryService service)
        {
            _service = service; 
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllIndustries();
            return Ok(result);
        }


        [HttpGet("details/{id:int}")]
        public async Task<ActionResult> getById([FromRoute] int id)
        {
            var result = await _service.GetIndustryById(id);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
