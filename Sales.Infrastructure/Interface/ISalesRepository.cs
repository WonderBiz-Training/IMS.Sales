using Sales.Domain.Entities;
using Sales.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Interface
{
    public interface ISalesRepository : IRepository<Sale>
    {
    }
}
