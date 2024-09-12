using Sales.Api.DTOs;
using Sales.Application.DTOs;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Interfaces
{
    public interface ISaleProductServices
    {
        public Task<IEnumerable<GetSalesProductDto>> GetAllSalesAsync();

        public Task<GetSalesProductDto> GetSalesAsync(Guid id);

        public Task<GetSalesProductDto> CreateSalesAsync(CreateSalesProductDto sales);

        public Task<GetSalesProductDto> UpdateSalesAsync(Guid id,UpdateSalesProductDto sales);

        public Task<bool> DeleteSalesAsync(Guid id);
    }
}
