using MediatR;
using Sales.Application.Commands;
using Sales.Application.DTOs;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Commands
{
    public class CreateSalesProductHandler : IRequestHandler<CreateSaleProductCommand, GetSalesProductDto>
    {
        private readonly ISaleProductRepository _saleProductRepository;
        public CreateSalesProductHandler(ISaleProductRepository saleProductRepository)
        {
            _saleProductRepository = saleProductRepository;
        }

        public async Task<GetSalesProductDto> Handle(CreateSaleProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sale = new SaleProduct
                {
                    SalesId = request.SalesId,
                    ProductId = request.ProductId,
                    ProductQuantity = request.ProductQuantity,
                    ProductTotal = request.ProductTotal,
                    DiscountId = request.DiscountId,
                    DiscountedTotal = request.DiscountedTotal,
                    CreatedAt = request.CreatedAt,
                    UpdatedAt = request.UpdatedAt,
                    CreatedBy = request.CreatedBy,
                    UpdatedBy = request.UpdatedBy
                };

                var res = await _saleProductRepository.CreateAsync(sale);

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
