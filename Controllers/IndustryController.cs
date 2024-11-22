using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API_ontwikkeling_LarsLauryssens.Models;
using Project_API_ontwikkeling_LarsLauryssens.Services;

namespace Project_API_ontwikkeling_LarsLauryssens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        private readonly IIndustryService _service;
        private readonly ILogger<IndustryController> _logger;

        public IndustryController(IIndustryService service, ILogger<IndustryController> logger)
        {
            _service = service; 
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> AAGetAllIndustries()
        {
            var result = await _service.GetAllIndustries();
            return Ok(result);
        }


        [HttpGet("details/{id:int}")]
        public async Task<ActionResult> AAgetIndustryById([FromRoute] int id)
        {
            try
            {
                var result = await _service.GetIndustryById(id);
                return Ok(result);

            }
            catch (Exception ex) 
            {
                return BadRequest("Industrycontroller getbyid: " + ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddIndustryToDataList([FromBody] Industry industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geen geldige data ingegeven");
            }
            try
            {
                await _service.AddIndustry(industry);
                return CreatedAtAction(nameof(AAgetIndustryById), new { id = industry.Id }, industry);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest("IndustryRouter " + ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateIndustryInDataBase([FromBody] Industry industry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geen geldige data ingegeven");
            }
            try
            {
                var result = await _service.UpdateIndustry(industry);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest("IndustryRouter " + ex.Message);
            }
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteIndustryFromDatabase([FromRoute] int id)
        {
            try
            {
                await _service.DeleteIndustry(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest("IndustryRouter " + ex.Message);
            }
        }


    }
}
