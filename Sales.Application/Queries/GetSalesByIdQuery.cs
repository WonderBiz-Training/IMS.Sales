using MediatR;
using Sales.Api.DTOs;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Queries
{
    public class GetSalesByIdQuery : BaseEntity , IRequest<GetSalesDto>
    {
        public new Guid Id { get; set; }
    }
}
