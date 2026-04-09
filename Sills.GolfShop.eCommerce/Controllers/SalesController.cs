using Sills.GolfShop.eCommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Sills.GolfShop.eCommerceAPI.Models;

namespace Sills.GolfShop.eCommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController(ISalesService salesService) : ControllerBase
    {
        private readonly ISalesService _salesService = salesService;

        [HttpGet]
        public ActionResult<List<Sales>> GetAllSales()
        {
            var sales = _salesService.GetAllSalesAsync().Result;
            return Ok(sales);
        }
        [HttpGet("{id}")]
        public ActionResult<Sales> GetSaleById(int id)
        {
            var sale = _salesService.GetSaleByIdAsync(id).Result;
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }
        [HttpPost]
        public ActionResult<Sales> CreateSale(Sales sale)
        {
            var createdSale = _salesService.CreateSaleAsync(sale).Result;
            return CreatedAtAction(nameof(GetSaleById), new { id = createdSale.Id }, createdSale);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, Sales sale)
        {
            var existingSale = _salesService.GetSaleByIdAsync(id).Result;
            if (existingSale == null)
            {
                return NotFound();
            }
            _salesService.UpdateSaleAsync(id, sale).Wait();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
                public IActionResult DeleteSale(int id)
        {
            var existingSale = _salesService.GetSaleByIdAsync(id).Result;
            if (existingSale == null)
            {
                return NotFound();
            }
            _salesService.DeleteSaleAsync(id).Wait();
            return NoContent();
        }
        
    }
}
