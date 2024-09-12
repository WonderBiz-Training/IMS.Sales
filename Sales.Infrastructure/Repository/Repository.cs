using Microsoft.EntityFrameworkCore;
using Sales.Infrastructure.Data;
using Sales.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SaleDbContext _dbcontext;

        public Repository(SaleDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _dbcontext.Set<T>().AddAsync(entity);
                await _dbcontext.SaveChangesAsync();
                return entity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _dbcontext.Remove(entity);
                var row = await _dbcontext.SaveChangesAsync();
                return row > 0;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var res = await _dbcontext.Set<T>().ToListAsync();
                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<T> GetAsync(Guid id)
        {
            try
            {
                var res =  await _dbcontext.Set<T>().FindAsync(id);
                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _dbcontext.Set<T>().Update(entity);
                await _dbcontext.SaveChangesAsync();
                return entity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
