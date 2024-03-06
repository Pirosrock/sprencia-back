using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Services.Horarios
{
    public interface IHorariosServices
    {
        Task<IEnumerable<Horario>> Getall();
    }
}
