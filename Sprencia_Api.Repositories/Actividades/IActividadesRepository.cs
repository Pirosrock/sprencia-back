using Sprencia_Api.Entities.API.Actividades.Requests.Update;
using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories.Actividades
{
    public interface IActividadesRepository
    {
        Task<IEnumerable<Actividad>> GetAll();
        Task<Actividad> Create(Actividad actividad);
        Task<Actividad?> Get(int id);
        Task<int> Update(int id, UpdateActividadRequest updateActividadRequest);
        Task<int> Desactivate(int id);
        Task<int> Activate(int id);
    }
}
