using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.DTOs;
using Sales.Application.DTOs;
using Sales.Application.Interfaces;
using Sales.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleProductController : ControllerBase
    {
        private readonly ISaleProductServices _salesServices;
        public SaleProductController(ISaleProductServices salesServices)
        {
            _salesServices = salesServices;
        }

        // GET: api/<SalesController>
        [HttpGet]
        public async Task<IEnumerable<GetSalesProductDto>> Get()
        {
            var data  = await _salesServices.GetAllSalesAsync();
            return data;
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSalesProductDto>> Get(Guid id)
        {
            try
            {
                var sale = await _salesServices.GetSalesAsync(id);
                return Ok(sale);
            }
            catch (Exception)
            {
                return NotFound($"Sale with ID {id} not found");
            }
        }

        // POST api/<SalesController>
        [HttpPost]
        public async Task<GetSalesProductDto> Post([FromBody] CreateSalesProductDto sale)
        {
            var data = await _salesServices.CreateSalesAsync(sale);
            return data;
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public async Task<GetSalesProductDto> Put(Guid id, [FromBody] UpdateSalesProductDto sale)
        {
            var data = await _salesServices.UpdateSalesAsync(id, sale);
            return data;
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var data = await _salesServices.DeleteSalesAsync(id);
            return data;
        }
    }
}
