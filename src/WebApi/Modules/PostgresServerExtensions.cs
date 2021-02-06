using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Domain.Invoices;
using Domain.Interfaces.InvoiceContext;
using Infrastructure.Repositories.InvoiceContext;
using Infrastructure.Services.InvoiceContext;

namespace WebApi.Modules
{
    /// <summary>
    ///     Persistence Extensions to isolate EF from Startup.
    /// </summary>
    public static class PostgresServerExtensions
    {
        /// <summary>
        ///     Add Persistence dependencies varying on configuration.
        /// </summary>
        public static IServiceCollection AddPostgresServer(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<InvoiceLabsContext>(
                options => options.UseNpgsql(configuration.GetValue<string>("PersistenceModule:DefaultConnection")));
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            return services;
        }
    }
}