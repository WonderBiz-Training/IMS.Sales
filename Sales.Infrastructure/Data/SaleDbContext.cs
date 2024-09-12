using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Data
{
    public class SaleDbContext : DbContext
    {
        public SaleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SaleProduct> Sales { get; set; }
        public DbSet<Sale> SaleHeaders { get; set; }
    }
}
