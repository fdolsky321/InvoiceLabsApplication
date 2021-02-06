using Domain.Interfaces.InvoiceContext;
using Domain.Invoices;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.InvoiceContext
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> InvoiceCreateNewAsync(Invoice invoice)
        {
            await _invoiceRepository.AddAsync(invoice);
            return invoice;
        }

        public async Task<Invoice> InvoiceEditAsync(Invoice invoice)
        {
            var existingInvoice = await _invoiceRepository.GetByIdAsync(invoice.Id);
            existingInvoice.UpdateInvoice(invoice.Identifier, invoice.TotalCharges, invoice.Description, invoice.InvoiceDate, invoice.CurrencyCode, invoice.Paid);
            await _invoiceRepository.UpdateAsync(existingInvoice);

            return existingInvoice;
        }

        public async Task<Invoice> InvoiceMakePaid(Invoice invoice)
        {
            var existingInvoice = await _invoiceRepository.GetByIdAsync(invoice.Id);
            existingInvoice.Paid = true;
            await _invoiceRepository.UpdateAsync(existingInvoice);
            
            return existingInvoice;
        }

    }
}
