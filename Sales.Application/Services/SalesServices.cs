using MediatR;
using Sales.Api.DTOs;
using Sales.Application.Commands;
using Sales.Application.Interfaces;
using Sales.Application.Queries;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interface;
using Sales.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Services
{
    public class SalesServices : ISalesServices
    {
        private readonly IMediator mediator;
        private readonly ISalesRepository saleHeaderRepository;

        public SalesServices(IMediator _mediator, ISalesRepository _saleHeaderRepository)
        {
            mediator = _mediator;
            saleHeaderRepository = _saleHeaderRepository;
        }
        public async Task<GetSalesDto> CreateSaleHeaderAsync(CreateSalesProductListDto saleHeader)
        {
            try
            {
                var command = new CreateSalesCommand
                {
                    SalesCode = saleHeader.SalesCode,
                    CustomerId = saleHeader.CustomerId,
                    SalesQuantity = saleHeader.SalesQuantity,
                    SalesTotal = saleHeader.SalesTotal * 10, 
                    DiscountId = saleHeader.DiscountId,
                    DiscountedTotal = saleHeader.SalesTotal - (saleHeader.SalesTotal * 0),  
                    TaxId = saleHeader.TaxId,
                    TaxedTotal = saleHeader.TaxedTotal,
                    StatusId = saleHeader.StatusId,
                    LocationId = saleHeader.LocationId,
                    SalesDate = saleHeader.SalesDate,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,

                    SaleProducts = saleHeader.SaleProducts.Select(x => new SaleProduct
                    {
                        SalesId = x.SalesId,
                        ProductId = x.ProductId,
                        ProductQuantity = x.ProductQuantity,
                        ProductTotal = x.ProductTotal,
                        DiscountId = x.DiscountId,
                        DiscountedTotal = x.DiscountedTotal,
                        TaxId = x.TaxId,
                        TaxedTotal = x.TaxedTotal
                    }).ToList()
                };

                var result = await mediator.Send(command);

                return result;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"An error occurred while creating the sale header: {ex.Message}");
            }
        }

        public async Task<bool> DeleteSaleHeaderAsync(Guid id)
        {
            var data = await mediator.Send(new DeleteSalesCommand { Id = id });
            return data;
        }

        public async Task<IEnumerable<GetSalesDto>> GetAllSaleHeadersAsync()
        {
            var data = await mediator.Send(new GetAllSalesQuery());
            return data;
        }

        public async Task<GetSalesDto> GetSaleHeaderAsync(Guid id)
        {
            try
            {
                var data = await mediator.Send(new GetSalesByIdQuery { Id = id });
                if (data == null)
                {
                    throw new KeyNotFoundException($"Sale Header with ID {id} not found");
                }
                return data;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<GetSalesDto> UpdateSaleHeaderAsync(Guid id, UpdateSalesDto saleHeader)
        {
            try
            {
                var oldSalesHeader = await saleHeaderRepository.GetAsync(id);

                if (oldSalesHeader == null)
                {
                    throw new KeyNotFoundException($"No Sales Header found for id {id}");
                }

                var command = new UpdateSalesCommand
                {
                    SalesCode = saleHeader.SalesCode != null ? saleHeader.SalesCode : oldSalesHeader.SalesCode,
                    CustomerId = saleHeader.CustomerId != Guid.Empty ? saleHeader.CustomerId : oldSalesHeader.CustomerId,
                    SalesQuantity = saleHeader.SalesQuantity != 0 ? saleHeader.SalesQuantity : oldSalesHeader.SalesQuantity,
                    SalesTotal = saleHeader.SalesTotal != null ? saleHeader.SalesTotal : oldSalesHeader.SalesTotal,
                    DiscountId = saleHeader.DiscountId != null ? saleHeader.DiscountId : oldSalesHeader.DiscountId,
                    DiscountedTotal = saleHeader.DiscountedTotal != null ? saleHeader.DiscountedTotal : oldSalesHeader.DiscountedTotal,
                    TaxId = saleHeader.TaxId != null ? saleHeader.TaxId : oldSalesHeader.TaxId,
                    TaxedTotal = saleHeader.TaxedTotal != null ? saleHeader.TaxedTotal : oldSalesHeader.TaxedTotal,
                    StatusId = saleHeader.StatusId != Guid.Empty ? saleHeader.StatusId : oldSalesHeader.StatusId,
                    LocationId = saleHeader.LocationId != Guid.Empty ? saleHeader.LocationId : oldSalesHeader.LocationId,
                    SalesDate = saleHeader.SalesDate != default(DateTime) ? saleHeader.SalesDate : oldSalesHeader.SalesDate,
                    UpdatedBy = saleHeader.UpdatedBy,
                    UpdatedAt = DateTime.Now,
                };

                var res = await mediator.Send(command);

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
