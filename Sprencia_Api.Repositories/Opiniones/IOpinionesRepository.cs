using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories.Opiniones
{
    public interface IOpinionesRepository
    {
        Task<int> Delete(int id);
        Task<IEnumerable<Opinion>> GetAll();
        Task<IEnumerable<Opinion?>> GetByActivityId(int id);
        Task<Opinion> Post(Opinion opinion);
    }
}
