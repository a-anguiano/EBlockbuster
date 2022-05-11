using EBlockbuster.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EBlockbuster.DAL
{
    public enum FactoryMode
    {
        TEST,
        PROD
    }
    public class DBFactory
    {
        public static DbContextOptions GetDbContext(FactoryMode mode)
        {
            string environment = mode == FactoryMode.TEST ? "Test" : "Prod";

            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<ConfigProvider>();
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(config[$"ConnectionStrings:{environment}"])
                .Options;
            return options;
        }
    }
}
