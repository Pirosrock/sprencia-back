using Sprencia_Api.Entities.API.Opiniones.Create;
using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Services.Opiniones
{
    public interface IOpinionesServices
    {
        Task Delete(int id);
        Task<IEnumerable<OpinionResponse>> GetAll();
        Task<IEnumerable<OpinionResponse?>> GetByActivityId(int activityId);
        Task<Opinion> Post(CreateOpinionRequest createOpinionRequest);
    }
}
