using MediatR;
using Sales.Api.DTOs;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Commands
{
    public class CreateSalesHandler : IRequestHandler<CreateSalesCommand, GetSalesDto>
    {
        private readonly ISalesRepository _saleHeaderRepository;

        public CreateSalesHandler(ISalesRepository saleHeaderRepository)
        {
            _saleHeaderRepository = saleHeaderRepository;
        }
        public async Task<GetSalesDto> Handle(CreateSalesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Create the sale header
                var saleHeader = new Sale
                {
                    SalesCode = request.SalesCode,
                    CustomerId = request.CustomerId,
                    SalesQuantity = request.SalesQuantity,
                    SalesTotal = request.SalesTotal,
                    DiscountId = request.DiscountId,
                    DiscountedTotal = request.DiscountedTotal,
                    TaxId = request.TaxId,
                    TaxedTotal = request.TaxedTotal,
                    StatusId = request.StatusId,
                    LocationId = request.LocationId,
                    SalesDate = request.SalesDate,
                    CreatedAt = DateTime.Now,
                    CreatedBy = request.CreatedBy,

                    SaleProducts = request.SaleProducts.Select(x => new SaleProduct
                    {
                        SalesId = x.SalesId,
                        ProductId = x.ProductId,
                        ProductQuantity = x.ProductQuantity,
                        ProductTotal = x.ProductTotal,
                        DiscountId = x.DiscountId,
                        DiscountedTotal = x.DiscountedTotal,
                        TaxId = x.TaxId,
                        TaxedTotal = x.TaxedTotal,
                        CreatedAt = DateTime.Now,
                        CreatedBy = request.CreatedBy,
                        UpdatedAt =  DateTime.Now,
                        UpdatedBy = x.CreatedBy
                    }).ToList() 
                };

                var result = await _saleHeaderRepository.CreateAsync(saleHeader);

                var responseDto = new GetSalesDto(
                    result.Id,
                    result.SalesCode,
                    result.CustomerId,
                    result.SalesQuantity,
                    result.SalesTotal,
                    result.DiscountId,
                    result.DiscountedTotal,
                    result.TaxId,
                    result.TaxedTotal,
                    result.StatusId,
                    result.LocationId,
                    result.SalesDate
                );

                return responseDto;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
