using Sills.GolfShop.eCommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Sills.GolfShop.eCommerceAPI.Models;
using Sills.GolfShop.eCommerceAPI.Helpers;

namespace Sills.GolfShop.eCommerceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController(ISalesService salesService) : ControllerBase
{
    private readonly ISalesService _salesService = salesService;

    [HttpGet]
    public ActionResult<List<Sales>> GetAllSales(PaginationParameters param)
    {
        var sales = _salesService.GetAllSalesAsync().Result;

        var pagedSales = sales
               .Skip((param.PageNumber - 1) * param.PageSize)
               .Take(param.PageSize)
               .ToList();

            return Ok(sales);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> GetSaleById(int id)
        {
            var sale = await _salesService.GetSaleByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }
        [HttpPost]
        public async Task<ActionResult<Sales>> CreateSale(Sales sale)
        {
            var createdSale = await _salesService.CreateSaleAsync(sale);
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
