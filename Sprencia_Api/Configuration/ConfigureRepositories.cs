using Sprencia_Api.Repositories.Actividad_Horarios;
using Sprencia_Api.Repositories.Actividades;
using Sprencia_Api.Repositories.Horarios;
using Sprencia_Api.Repositories.Opiniones;
using Sprencia_Api.Repositories.Usuarios;

namespace Sprencia_Api.Configuration
{
    internal static class ConfigureRepositories
    {
        internal static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IActividadesRepository, ActividadesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IOpinionesRepository, OpinionesRepository>();
            services.AddScoped<IHorariosRepository, HorariosRepository>();
            services.AddScoped<IActividad_HorariosRepository, Actividad_HorariosRepository >();
        }
    }
}
