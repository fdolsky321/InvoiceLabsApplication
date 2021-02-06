using Domain.SharedKernel;
using System;

namespace Domain.Invoices
{
    /// <summary>
    /// Following https://github.com/opendata-mvcr/otevrene-formalni-normy/blob/master/faktury/draft/sch%C3%A9mata/faktury.json
    /// Made just simple object to simplify this demo project
    /// </summary>
    public class Invoice : BaseUpdateEntity
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public decimal TotalCharges { get; set; }
        public string Description { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CurrencyCode { get; set; }
        public bool Paid { get; set; }

        public Invoice() { }

        public Invoice(string identifier, decimal totalCharges, string description, DateTime invoiceDate, string currencyCode, bool paid)
        {
            Identifier = identifier;
            TotalCharges = totalCharges;
            Description = description;
            InvoiceDate = invoiceDate;
            CurrencyCode = currencyCode;
            Paid = paid;
        }

        public void UpdateInvoice(string identifier, decimal totalCharges, string description, DateTime invoiceDate, string currencyCode, bool paid)
        {
            Identifier = identifier;
            TotalCharges = totalCharges;
            Description = description;
            InvoiceDate = invoiceDate;
            CurrencyCode = currencyCode;
            Paid = paid;
        }
    }

    
}