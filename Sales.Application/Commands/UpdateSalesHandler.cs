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
    public class UpdateSalesHandler : IRequestHandler<UpdateSalesCommand, GetSalesDto>
    {
        private readonly ISalesRepository _saleHeaderRepository;
        public UpdateSalesHandler(ISalesRepository saleHeaderRepository)
        {
            _saleHeaderRepository = saleHeaderRepository;
        }

        public async Task<GetSalesDto> Handle(UpdateSalesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var saleHeader = new Sale
                {
                    SalesCode = request.SalesCode ?? string.Empty,
                    CustomerId = request.CustomerId ?? Guid.Empty,
                    SalesDate = request.SalesDate ?? DateTime.Now,
                    SalesQuantity = request.SalesQuantity ?? 0L,
                    SalesTotal = request.SalesTotal,
                    DiscountId = request.DiscountId,
                    DiscountedTotal = request.DiscountedTotal,
                    TaxId = request.TaxId,
                    TaxedTotal = request.TaxedTotal,
                    StatusId = request.StatusId ?? Guid.Empty,
                    LocationId = request.LocationId ?? Guid.Empty,
                    CreatedBy = request.CreatedBy,
                    UpdatedBy = request.CreatedBy,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                var res = await _saleHeaderRepository.UpdateAsync(saleHeader);

                var resDto = new GetSalesDto(
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
