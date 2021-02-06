using Domain.Interfaces.InvoiceContext;
using Domain.Invoices;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.InvoiceContext
{
    public class InvoiceRepository : EfRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceLabsContext invoiceLabsContext) : base(invoiceLabsContext) { }

        public async Task<Invoice> GetByIdAsync(Guid id)
        {
            return await _invoiceLabsContext.Invoices.SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<List<Invoice>> ListAllAsync()
        {
            return await _invoiceLabsContext.Invoices.ToListAsync();
        }

        public async Task<List<Invoice>> ListUnpaid()
        {
            return await _invoiceLabsContext.Invoices.Where(_ => _.Paid == false).ToListAsync();
        }
    }
}
