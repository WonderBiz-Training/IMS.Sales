using MediatR;
using Sales.Application.Commands;
using Sales.Application.DTOs;
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
    public class SaleProductServices : ISaleProductServices
    {
        private readonly IMediator mediator;
        private readonly ISaleProductRepository saleRepository;

        public SaleProductServices(IMediator _mediator,ISaleProductRepository _saleRepository)
        {
           mediator = _mediator;
           saleRepository = _saleRepository;
        }

        public async Task<GetSalesProductDto> CreateSalesAsync(CreateSalesProductDto sales)
        {
            var command = new CreateSaleProductCommand
            {
                SalesId = sales.SalesId,
                ProductId = sales.ProductId,
                ProductQuantity = sales.ProductQuantity,
                ProductTotal = 10 * sales.ProductQuantity,
                DiscountId = sales.DiscountId,
                DiscountedTotal = sales.ProductTotal - (sales.ProductTotal * 0),
                TaxId = sales.TaxId,
                TaxedTotal = sales.TaxedTotal,
                CreatedBy = sales.CreatedBy,
                UpdatedBy = sales.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var result = await mediator.Send(command);

            return result;
        }

        public async Task<bool> DeleteSalesAsync(Guid id)
        {
            var sale = await mediator.Send(new DeleteSaleProductCommand { Id = id});
            return sale;
        }

        public async Task<IEnumerable<GetSalesProductDto>> GetAllSalesAsync()
        {
            var sales = await mediator.Send(new GetAllSaleProductQuery());
            return sales;
        }

        public async Task<GetSalesProductDto> GetSalesAsync(Guid id)
        {
            try
            {
                var sale = await mediator.Send(new GetSaleProductByIdQuery { Id = id });
                if (sale == null)
                {
                    throw new KeyNotFoundException($"Sale with ID {id} not found");
                }
            return sale;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }



        public async Task<GetSalesProductDto> UpdateSalesAsync(Guid id, UpdateSalesProductDto sales)
        {
            try
            {
                var oldSale = await saleRepository.GetAsync(id);

                if (oldSale == null)
                {
                    throw new KeyNotFoundException($"No Sales Found for id : {id}");
                }


                var command = new UpdateSaleProductCommand
                {
                    SalesId = sales.SalesId != Guid.Empty ? sales.SalesId : oldSale.SalesId,
                    ProductId = sales.ProductId != Guid.Empty ? sales.ProductId : oldSale.ProductId,
                    ProductQuantity = sales.ProductQuantity != 0 ? sales.ProductQuantity : oldSale.ProductQuantity,
                    ProductTotal = sales.ProductTotal != null ? 10 * sales.ProductQuantity : oldSale.ProductTotal,
                    DiscountId = sales.DiscountId != null ? sales.DiscountId : oldSale.DiscountId,
                    DiscountedTotal = sales.DiscountedTotal != null ? sales.DiscountedTotal : oldSale.DiscountedTotal,
                    TaxId = sales.TaxId != null ? sales.TaxId : oldSale.TaxId,
                    TaxedTotal = sales.TaxedTotal != null ? sales.TaxedTotal : oldSale.TaxedTotal,
                    UpdatedBy = sales.UpdatedBy,
                    UpdatedAt = DateTime.Now
                };


                // Send the command to the mediator
                var result = await mediator.Send(command);
                return result;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

    }
}
