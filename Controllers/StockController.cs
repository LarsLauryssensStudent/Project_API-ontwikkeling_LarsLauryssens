using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API_ontwikkeling_LarsLauryssens.Models;
using Project_API_ontwikkeling_LarsLauryssens.Services;

namespace Project_API_ontwikkeling_LarsLauryssens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _service;
        private readonly ILogger<StockController> _logger;


        public StockController(IStockService service, ILogger<StockController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> AAGetAll()
        {
            var results = await _service.GetAllStocks();
            return Ok(results); 
        }

        [HttpGet("details/{id::int}")]
        public async Task<ActionResult> AAGetById([FromRoute] int id)
        {
            try
            {
                var result = await _service.GetStockById(id);
                return Ok(result);

            }
            catch (Exception ex) 
            {
                return BadRequest("StockRouter: " + ex.Message);

            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddStockToDataList([FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geen geldige data ingegeven");
            }
            try
            {
                await _service.AddStock(stock);
                return CreatedAtAction(nameof(AAGetById), new { id = stock.Id }, stock);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest("StockRouter " + ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateStockInDataBase([FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geen geldige data ingegeven");
            }
            try
            {
                var result = await _service.UpdateStock(stock);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest("StockRouter " + ex.Message);
            }
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteStockFromDatabase([FromRoute] int id)
        {
            try
            {
                await _service.DeleteStock(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest("StockRouter " + ex.Message);
            }
        }
    }
}
