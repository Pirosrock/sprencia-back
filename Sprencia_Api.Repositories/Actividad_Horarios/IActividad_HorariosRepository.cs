using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories.Actividad_Horarios
{
    public interface IActividad_HorariosRepository
    {
        Task<IEnumerable<Actividad_horarios>> GetAll();
        Task<IEnumerable<Actividad_horarios>> GetByActivityId(int id);
    }
}
