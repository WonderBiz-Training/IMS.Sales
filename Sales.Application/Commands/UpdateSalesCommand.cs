using MediatR;
using Sales.Api.DTOs;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Commands
{
    public class UpdateSalesCommand : BaseEntity, IRequest<GetSalesDto>
    {
        public string? SalesCode { get; set; }
        public Guid? CustomerId { get; set; }
        public long? SalesQuantity { get; set; }
        public double? SalesTotal { get; set; }
        public Guid? DiscountId { get; set; }
        public double? DiscountedTotal { get; set; }
        public Guid? TaxId { get; set; }
        public double? TaxedTotal { get; set; }
        public Guid? StatusId { get; set; }
        public Guid? LocationId { get; set; }
        public DateTime? SalesDate { get; set; } = DateTime.Now;
    }
}
