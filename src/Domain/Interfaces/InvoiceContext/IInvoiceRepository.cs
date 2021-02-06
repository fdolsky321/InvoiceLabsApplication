using Domain.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InvoiceContext
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<Invoice> GetByIdAsync(Guid id);
        Task<List<Invoice>> ListAllAsync();
        Task<List<Invoice>> ListUnpaid();
    }
}
