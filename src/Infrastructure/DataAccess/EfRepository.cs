using Domain.Interfaces;
using Domain.SharedKernel;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity 
    {
        protected readonly InvoiceLabsContext _invoiceLabsContext;

        public EfRepository(InvoiceLabsContext invoiceLabsContext)
        {
            _invoiceLabsContext = invoiceLabsContext;
        }

        public virtual List<T> List()
        {
            return _invoiceLabsContext.Set<T>().ToList();
        }

        public virtual async Task<List<T>> ListAsync()
        {
            return await _invoiceLabsContext.Set<T>().ToListAsync();
        }

        public T Add(T entity)
        {
            _invoiceLabsContext.Set<T>().Add(entity);
            _invoiceLabsContext.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _invoiceLabsContext.Set<T>().Add(entity);
            await _invoiceLabsContext.SaveChangesAsync();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _invoiceLabsContext.Set<T>().Remove(entity);
            _invoiceLabsContext.SaveChanges();
        }

        public async void DeleteAsync(T entity)
        {
            _invoiceLabsContext.Set<T>().Remove(entity);
            await _invoiceLabsContext.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            _invoiceLabsContext.Entry(entity).State = EntityState.Modified;
            _invoiceLabsContext.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _invoiceLabsContext.Entry(entity).State = EntityState.Modified;
            await _invoiceLabsContext.SaveChangesAsync();
            return entity;
        }
    }
}
