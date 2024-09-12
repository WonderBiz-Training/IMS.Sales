using MediatR;
using Sales.Application.DTOs;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Queries
{
    public class GetAllSaleProductQuery : BaseEntity, IRequest<IEnumerable<GetSalesProductDto>>
    {
       

    }
}
