using Sprencia_Api.Services.Actividad_Horarios;
using Sprencia_Api.Services.Actividades;
using Sprencia_Api.Services.Horarios;
using Sprencia_Api.Services.Opiniones;
using Sprencia_Api.Services.Security;
using Sprencia_Api.Services.Usuarios;

namespace Sprencia_Api.Configuration
{
    internal static class ConfigureCustomServices
    {
        internal static void AddCustomServices(IServiceCollection services)
        {
            services.AddScoped<IActividadesServices, ActividadesServices>();
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IEncryptService, EncryptionService>();
            services.AddScoped<IOpinionesServices, OpinionesServices>();
            services.AddScoped<IHorariosServices, HorariosServices>();
            services.AddScoped<IActividad_HorariosServices, Actividad_HorariosServices>();
        }
    }
}
