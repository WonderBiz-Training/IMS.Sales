using MediatR;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Commands
{
    public class DeleteSaleProductCommand : BaseEntity, IRequest<bool>
    {
        public new Guid Id { get; set; }
        
    }
}
