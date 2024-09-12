using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Interface
{
    public interface ISaleProductRepository : IRepository<SaleProduct>
    {
    }
}
