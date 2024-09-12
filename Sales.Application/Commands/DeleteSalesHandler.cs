using MediatR;
using Sales.Infrastructure.Interface;
using Sales.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Commands
{
    public class DeleteSalesHandler : IRequestHandler<DeleteSalesCommand, bool>
    {
        private readonly ISalesRepository saleHeaderRepository;

        public DeleteSalesHandler(ISalesRepository _saleHeaderRepository)
        {
            saleHeaderRepository = _saleHeaderRepository;
        }
        public async Task<bool> Handle(DeleteSalesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sale = await saleHeaderRepository.GetAsync(request.Id);

                if (sale == null)
                {
                    throw new KeyNotFoundException($"Sale Header with ID {request.Id} not found.");
                }

                var success = await saleHeaderRepository.DeleteAsync(sale);
                return success;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"An error occurred while deleting the sale: {ex.Message}");
            }
        }
    }
}
