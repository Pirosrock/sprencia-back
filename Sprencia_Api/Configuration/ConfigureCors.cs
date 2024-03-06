namespace Sprencia_Api.Configuration
{
    internal static class ConfigureCors
    {
        internal static void AllowOrigins(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: configuration["CORS:PolicyName"], builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }
    }
}
