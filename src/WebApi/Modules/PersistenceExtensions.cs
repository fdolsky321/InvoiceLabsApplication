using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace InvoiceLabsApplication.Web.Modules
{
    /// <summary>
    ///     Persistence Extensions to isolate EF from Startup.
    /// </summary>
    public static class PersistenceExtensions
    {
        /// <summary>
        ///     Add Persistence dependencies varying on configuration.
        /// </summary>
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<InvoiceLabsContext>(
                options => options.UseNpgsql(configuration.GetValue<string>("PersistenceModule:DefaultConnection")));
            return services;
        }
    }
}