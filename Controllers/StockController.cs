using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API_ontwikkeling_LarsLauryssens.Services;

namespace Project_API_ontwikkeling_LarsLauryssens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _service;

        public StockController(IStockService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> getAll()
        {
            var results = await _service.GetAllStocks();
            return Ok(results); 
        }

        [HttpGet("details/{id::int}")]
        public async Task<ActionResult> getById([FromRoute] int id)
        {
            var result = await _service.GetStockById(id);
            if (result == null)
            {
                return BadRequest("niks gevonden");

            }
            return Ok(result);
        }
    }
}
