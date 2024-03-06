using Sprencia_Api.Entities.EF;
using Sprencia_Api.Repositories.Actividad_Horarios;

namespace Sprencia_Api.Services.Actividad_Horarios
{
    public class Actividad_HorariosServices : IActividad_HorariosServices
    {
        readonly IActividad_HorariosRepository _actividad_HorariosRepository;

        public Actividad_HorariosServices(IActividad_HorariosRepository actividad_HorariosRepository)
        {
            _actividad_HorariosRepository = actividad_HorariosRepository;
        }

        public async Task<IEnumerable<Actividad_horarios>> GetAll()
        {
            return await _actividad_HorariosRepository.GetAll();
        }

        public async Task<IEnumerable<Actividad_horarios>> GetByActivityId(int id)
        {
            return await _actividad_HorariosRepository.GetByActivityId(id);
        }
    }
}
