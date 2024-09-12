using MediatR;
using Sales.Application.DTOs;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Queries
{
    public class GetAllSaleProductHandler : IRequestHandler<GetAllSaleProductQuery, IEnumerable<GetSalesProductDto>>
    {
        private readonly ISaleProductRepository _saleRepository;
        public GetAllSaleProductHandler(ISaleProductRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<IEnumerable<GetSalesProductDto>> Handle(GetAllSaleProductQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.GetAllAsync();

            var resDto = sales.Select(res => new GetSalesProductDto
            (
                res.Id,
                res.SalesId,
                res.ProductId,
                res.ProductQuantity,
                res.ProductTotal,
                res.DiscountId,
                res.DiscountedTotal,
                res.TaxId,
                res.TaxedTotal
            ));

        return resDto;
        }

    }
}
