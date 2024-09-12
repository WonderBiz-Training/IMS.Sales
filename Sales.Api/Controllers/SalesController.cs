using Microsoft.AspNetCore.Http.HttpResults;
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
    public class SalesController : ControllerBase
    {
        private readonly ISalesServices _salesHeaderServices;
        public SalesController(ISalesServices salesHeaderServices)
        {
            _salesHeaderServices = salesHeaderServices;
        }

        // GET: api/<SaleHeaderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSalesDto>>> Get()
        {
            try
            {
                var res = await _salesHeaderServices.GetAllSaleHeadersAsync();
                return  Ok(res);
            }
            catch (Exception)
            {
                return NotFound("Sales Not Found");
            }
        }

        // GET api/<SaleHeaderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSalesDto>> Get(Guid id)
        {
            try
            {
                var res = await _salesHeaderServices.GetSaleHeaderAsync(id);
                return Ok(res);
            }
            catch (Exception)
            {
                return NotFound($"Sale header with ID {id} not found");
            }
        }

        // POST api/<SaleHeaderController>
        [HttpPost]
        public async Task<ActionResult<GetSalesDto>> Post([FromBody] CreateSalesProductListDto saleHeader)
        {
            try
            {
                var data = await _salesHeaderServices.CreateSaleHeaderAsync(saleHeader);
                return data;
            }
            catch (Exception)
            {
                return NotFound("Duplicate Sales Code");
            }
        }

        // PUT api/<SaleHeaderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetSalesDto>> Put(Guid id, [FromBody] UpdateSalesDto saleHeader)
        {
            try
            {
                var data = await _salesHeaderServices.UpdateSaleHeaderAsync(id, saleHeader);
                return data;
            }
            catch (Exception)
            {
                return NotFound("Sales Not Updated");
            }
        }

        // DELETE api/<SaleHeaderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                var data = await _salesHeaderServices.DeleteSaleHeaderAsync(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return NotFound("Sales Not Deleted");
            }
        }
    }
}
