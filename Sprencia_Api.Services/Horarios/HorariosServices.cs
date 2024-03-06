using Sprencia_Api.Entities.EF;
using Sprencia_Api.Repositories.Horarios;

namespace Sprencia_Api.Services.Horarios
{
    public class HorariosServices : IHorariosServices
    {
        readonly IHorariosRepository _horariosRepository;

        public HorariosServices(IHorariosRepository horariosRepository)
        {
            _horariosRepository = horariosRepository;
        }

        public async Task<IEnumerable<Horario>> Getall()
        {
            return await _horariosRepository.GetAll();
        }
    }
}
