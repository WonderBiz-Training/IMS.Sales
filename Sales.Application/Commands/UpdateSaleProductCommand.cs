using MediatR;
using Sales.Application.DTOs;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Commands
{
    public class UpdateSaleProductCommand : BaseEntity, IRequest<GetSalesProductDto>
    {
        public Guid? SalesId { get; set; }
        public Guid? ProductId { get; set; }
        public long? ProductQuantity { get; set; }
        public double? ProductTotal { get; set; }
        public Guid? DiscountId { get; set; }
        public double? DiscountedTotal { get; set; }
        public Guid? TaxId { get; set; }
        public double? TaxedTotal { get; set; }
    }
}
