using MediatR;
using Sales.Api.DTOs;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interface;
using Sales.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Queries
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesQuery, IEnumerable<GetSalesDto>>
    {
        private readonly ISalesRepository saleHeaderRepository;
        public GetAllSalesHandler(ISalesRepository _saleHeaderRepository)
        {
            saleHeaderRepository = _saleHeaderRepository;
        }
        public async Task<IEnumerable<GetSalesDto>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = await saleHeaderRepository.GetAllAsync();

            var resDto = sales.Select(res => new GetSalesDto(
                res.Id,
                res.SalesCode,
                res.CustomerId,
                res.SalesQuantity,
                res.SalesTotal,
                res.DiscountId,
                res.DiscountedTotal,
                res.TaxId,
                res.TaxedTotal,
                res.StatusId,
                res.LocationId,
                res.SalesDate
            ));

            return resDto;
        }
    }
}
