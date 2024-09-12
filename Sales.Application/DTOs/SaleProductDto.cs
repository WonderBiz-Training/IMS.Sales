using Sales.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sales.Application.DTOs
{
    public class SaleProductDto
    {
        public SaleProductDto()
        {
        }

    }
        public record CreateSalesProductDto(
            Guid SalesId,
            Guid ProductId,
            long ProductQuantity,
            double? ProductTotal,
            Guid? DiscountId,
            double? DiscountedTotal,
            Guid? TaxId,
            double? TaxedTotal,
            Guid CreatedBy
        );

        public record UpdateSalesProductDto(
            Guid? SalesId,
            Guid? ProductId,
            long? ProductQuantity,
            double? ProductTotal,
            Guid? DiscountId,
            double? DiscountedTotal,
            Guid? TaxId,
            double? TaxedTotal,
            Guid UpdatedBy
        );

        public record GetSalesProductDto(
            Guid Id,
            Guid SalesId,
            Guid ProductId,
            long ProductQuantity,
            double? ProductTotal,
            Guid? DiscountId,
            double? DiscountedTotal,
            Guid? TaxId,
            double? TaxedTotal

        );
}
