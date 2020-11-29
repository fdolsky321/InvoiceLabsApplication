using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataAccess
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<InvoiceLabsContext>
    {
        public InvoiceLabsContext CreateDbContext(string[] args)
        {
            string connectionString = ReadDefaultConnectionStringFromAppSettings();
            
            DbContextOptionsBuilder<InvoiceLabsContext> builder = new DbContextOptionsBuilder<InvoiceLabsContext>();
            Console.WriteLine(connectionString);
            builder.UseSqlServer(connectionString);
            builder.EnableSensitiveDataLogging();
            return new InvoiceLabsContext(builder.Options);   
        }
        
        private static string ReadDefaultConnectionStringFromAppSettings()
        {
            string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{envName}.json", false)
                .AddEnvironmentVariables()
                .Build();

            string connectionString = configuration.GetValue<string>("PersistenceModule:DefaultConnection");
            return connectionString;
        }
    }
}