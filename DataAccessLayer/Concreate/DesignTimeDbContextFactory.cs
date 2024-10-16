using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DataAccessLayer.Concreate
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            // IConfigurationBuilder'dan IConfiguration nesnesi oluşturuluyor
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Shopier\appsettings.json"), optional: true)
                .Build();

            // IConfiguration kullanarak bağlantı dizesi alınması
            var connectionString = configuration.GetConnectionString("Shopier");
            optionsBuilder.UseSqlServer(connectionString);

            return new Context(optionsBuilder.Options, configuration);
        }
    }
}
