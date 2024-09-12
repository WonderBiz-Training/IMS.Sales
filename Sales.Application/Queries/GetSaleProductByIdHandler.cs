using MediatR;
using Sales.Application.DTOs;
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
    public class GetSaleProductByIdHandler : IRequestHandler<GetSaleProductByIdQuery, GetSalesProductDto>
    {
        private readonly ISaleProductRepository saleRepository;
        public GetSaleProductByIdHandler(ISaleProductRepository _saleRepository)
        {
            saleRepository = _saleRepository;
        }

        public async Task<GetSalesProductDto> Handle(GetSaleProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await saleRepository.GetAsync(request.Id);
                if (res == null)
                {
                    throw new InvalidOperationException($"Sale with id {request.Id} not found");
                }

                var resDto = new GetSalesProductDto
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
                );

                return resDto;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
