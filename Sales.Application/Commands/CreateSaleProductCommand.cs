using MediatR;
using Sales.Application.DTOs;
using Sales.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sales.Application.Commands
{
    public class CreateSaleProductCommand : BaseEntity, IRequest<GetSalesProductDto>
    {
        public Guid SalesId { get; set; }

        [Required(ErrorMessage = "Product Id is required")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Product Quantity is required")]
        public long ProductQuantity { get; set; }
        public double? ProductTotal { get; set; }
        public Guid? DiscountId { get; set; }
        public double? DiscountedTotal { get; set; }
        public Guid? TaxId { get; set; }
        public double? TaxedTotal { get; set; }
    }
}
