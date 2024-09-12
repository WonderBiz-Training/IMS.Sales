using Sales.Api.DTOs;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Interfaces
{
    public interface ISalesServices
    {
        public Task<IEnumerable<GetSalesDto>> GetAllSaleHeadersAsync();
        
        public Task<GetSalesDto> GetSaleHeaderAsync(Guid id);

        public Task<GetSalesDto> CreateSaleHeaderAsync(CreateSalesProductListDto saleHeader);

        public Task<GetSalesDto> UpdateSaleHeaderAsync(Guid id,UpdateSalesDto saleHeader);

        public Task<bool> DeleteSaleHeaderAsync(Guid id);
    }
}
