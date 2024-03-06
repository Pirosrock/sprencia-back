using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories.Horarios
{
    public interface IHorariosRepository
    {
        Task<IEnumerable<Horario>> GetAll();
    }
}
