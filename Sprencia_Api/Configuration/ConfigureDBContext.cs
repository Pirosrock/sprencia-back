using Microsoft.EntityFrameworkCore;
using Sprencia_Api.Repositories;

namespace Sprencia_Api.Configuration
{
    internal static class ConfigureDBContext
    {
        internal static void AddDBContext(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("connectionString")));

        }
    }
}
