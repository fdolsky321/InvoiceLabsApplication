using Domain.Invoices;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.DataAccess
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder) 
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Entity<Invoice>()
                .HasData(
                    new Invoice
                    {
                        Id = new Guid("bcc6c5c0-ab74-4c4b-9415-2e21b15ba53e"),
                        Identifier = "AAA-111-BBB-222",
                        TotalCharges = 123.0M,
                        Description = "First testing invoice",
                        InvoiceDate = DateTime.Now,
                        CurrencyCode = "CZK",
                        Paid = false,
                        CreatedAt = DateTime.Now,
                        CreatedBy = "Frantisek Dolsky",
                        ModifiedAt = DateTime.Now,
                        ModifiedBy = "Frantisek Dolsky"
                    }
                ) ;
        }
    }
}