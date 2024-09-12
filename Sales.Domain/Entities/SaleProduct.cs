using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Entities
{
    [Table("SalesProduct")]
    public class SaleProduct : BaseEntity
    {
        public virtual Sale? Sales { get; set; }
        public Guid SalesId { get; set; }
        public Guid ProductId { get; set; }
        public long ProductQuantity { get; set; }
        public double? ProductTotal { get; set; }
        public Guid? DiscountId { get; set; }
        public double? DiscountedTotal { get; set; }
        public Guid? TaxId { get; set; }
        public double? TaxedTotal { get; set; }
    }
}
