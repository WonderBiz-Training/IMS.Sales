using MediatR;
using Sales.Application.Commands;
using Sales.Application.DTOs;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Commands
{
    public class UpdateSaleProductHandler : IRequestHandler<UpdateSaleProductCommand, GetSalesProductDto>
    {
        private readonly ISaleProductRepository _saleRepository;

        public UpdateSaleProductHandler(ISaleProductRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<GetSalesProductDto> Handle(UpdateSaleProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sale = new SaleProduct
                {
                    SalesId = request.SalesId ?? Guid.Empty,
                    ProductId = request.ProductId ?? Guid.Empty,
                    ProductQuantity = request.ProductQuantity ?? 0,
                    ProductTotal = request.ProductTotal,
                    DiscountId = request.DiscountId,
                    DiscountedTotal = request.DiscountedTotal,
                    TaxId = request.TaxId,
                    TaxedTotal = request.TaxedTotal,
                    UpdatedAt = request.UpdatedAt,
                    UpdatedBy = request.UpdatedBy
                };

                var res =  await _saleRepository.UpdateAsync(sale);

                var resDto = new GetSalesProductDto(
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
