using Sales.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Sales.Api.DTOs
{
    public class SalesDto
    {
        public SalesDto()
        {
        }

    }
        public record CreateSalesDto(
             string SalesCode,
             Guid CustomerId,
            // long ProductId,
             long SalesQuantity,
            // long ProductPrice,
             double? SalesTotal,
             Guid? DiscountId,
             double? DiscountedTotal,
             Guid? TaxId,
             double? TaxedTotal,
             Guid StatusId,
             Guid LocationId,
             DateTime SalesDate,
             Guid CreadtedBy
        );


    public record CreateSalesProductListDto(
         string SalesCode,
         [Required(ErrorMessage = "CustomerId is required")] Guid CustomerId,
         // long ProductId,
         long SalesQuantity,
         // long ProductPrice,
         double? SalesTotal,
         Guid? DiscountId,
         double? DiscountedTotal,
         Guid? TaxId,
         double? TaxedTotal,
         Guid StatusId,
         Guid LocationId,
         DateTime SalesDate,
         Guid CreadtedBy,
         List<SaleProduct> SaleProducts
    );
    public record UpdateSalesDto(
             string? SalesCode,
             Guid? CustomerId,
             // long ProductId,
             long? SalesQuantity,
             // long ProductPrice,
             double? SalesTotal,
             Guid? DiscountId,
             double? DiscountedTotal,
             Guid? TaxId,
             double? TaxedTotal,
             Guid? StatusId,
             Guid? LocationId,
             DateTime? SalesDate,
             Guid UpdatedBy
         );

        public record GetSalesDto(
             Guid Id,
             string SalesCode,
             Guid CustomerId,
             // long ProductId,
             long SalesQuantity,
             // long ProductPrice,
             double? SalesTotal,
             Guid? DiscountId,
             double? DiscountedTotal,
             Guid? TaxId,
             double? TaxedTotal,
             Guid StatusId,
             Guid LocationId,
             DateTime SalesDate
        );
}
