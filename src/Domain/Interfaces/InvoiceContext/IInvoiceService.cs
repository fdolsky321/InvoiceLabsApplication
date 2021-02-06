using Domain.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InvoiceContext
{
    public interface IInvoiceService
    {
        Task<Invoice> InvoiceCreateNewAsync(Invoice invoice);
        Task<Invoice> InvoiceEditAsync(Invoice invoice);
        Task<Invoice> InvoiceMakePaid(Invoice invoice);
    }
}
