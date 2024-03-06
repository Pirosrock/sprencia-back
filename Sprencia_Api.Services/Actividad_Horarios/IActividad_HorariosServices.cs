using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Services.Actividad_Horarios
{
    public interface IActividad_HorariosServices
    {
        Task<IEnumerable<Actividad_horarios>> GetAll();
        Task<IEnumerable<Actividad_horarios>> GetByActivityId(int id);
    }
}
