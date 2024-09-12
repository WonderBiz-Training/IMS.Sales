using Sales.Domain.Entities;
using Sales.Infrastructure.Data;
using Sales.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repository
{
    public class SalesRepository : Repository<Sale>, ISalesRepository
    {
        public SalesRepository(SaleDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
