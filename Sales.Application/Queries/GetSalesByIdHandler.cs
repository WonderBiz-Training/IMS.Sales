using MediatR;
using Sales.Api.DTOs;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Queries
{
    public class GetSalesByIdHandler : IRequestHandler<GetSalesByIdQuery, GetSalesDto>
    {
        private readonly ISalesRepository saleHeaderRepository;
        public GetSalesByIdHandler(ISalesRepository _saleHeaderRepository)
        {
            saleHeaderRepository = _saleHeaderRepository;
        }

        public async Task<GetSalesDto> Handle(GetSalesByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await saleHeaderRepository.GetAsync(request.Id);
                if (res == null)
                {
                    throw new InvalidOperationException($"Sales with id {request.Id} not found");
                }

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
            catch (InvalidOperationException ex )
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
