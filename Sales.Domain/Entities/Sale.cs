using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sales.Domain.Entities
{
    [Table("Sales")]
    [Index(nameof(SalesCode), IsUnique = true)]
    public class Sale : BaseEntity
    {
        public required string SalesCode { get; set; }
        public Guid CustomerId { get; set; }
        public long SalesQuantity { get; set; }

        public double? SalesTotal { get; set; }

        public Guid? DiscountId { get; set; }

        public double? DiscountedTotal { get; set; }

        public Guid? TaxId { get; set; }
        public double? TaxedTotal { get; set; }
        public Guid StatusId { get; set; }

        public Guid LocationId { get; set; }

        public DateTime SalesDate { get; set; } = DateTime.Now;

        public List<SaleProduct> SaleProducts { get; set; } = new List<SaleProduct>();
    }
}
