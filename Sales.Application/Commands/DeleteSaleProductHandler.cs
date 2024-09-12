using MediatR;
using Sales.Domain.Entities;
using Sales.Infrastructure.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sales.Application.Commands
{
    public class DeleteSaleProductHandler : IRequestHandler<DeleteSaleProductCommand, bool>
    {
        private readonly ISaleProductRepository saleRepository;

        public DeleteSaleProductHandler(ISaleProductRepository _saleRepository)
        {
            saleRepository = _saleRepository;
        }

        public async Task<bool> Handle(DeleteSaleProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sale = await saleRepository.GetAsync(request.Id);

                if(sale == null)
                {
                    throw new KeyNotFoundException($"Sale with ID {request.Id} not found.");
                }

                var success = await saleRepository.DeleteAsync(sale);
                return success;
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"An error occurred while deleting the sale: {ex.Message}");
            }
        }

    }
}
