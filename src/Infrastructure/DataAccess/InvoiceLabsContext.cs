using System;
using Microsoft.EntityFrameworkCore;
using Domain.Invoices;

namespace Infrastructure.DataAccess
{
    using System;
    using Microsoft.EntityFrameworkCore;
    public sealed class InvoiceLabsContext : DbContext
    {
        public InvoiceLabsContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Invoice> Invoices { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ApplyConfigurationsFromAssembly(typeof(InvoiceLabsContext).Assembly);
            SeedData.Seed(builder);
        }
    }
}