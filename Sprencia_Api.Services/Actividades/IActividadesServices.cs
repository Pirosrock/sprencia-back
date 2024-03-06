using Sprencia_Api.Entities.API.Actividades.Requests.Create;
using Sprencia_Api.Entities.API.Actividades.Requests.Update;
using Sprencia_Api.Entities.API.Actividades.Responses;
using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Services.Actividades
{
    public interface IActividadesServices
    {
        Task<IEnumerable<ActividadResponse>> Getall();
        Task<Actividad> Create(CreateActividadRequest CreateActividadRequest);
        Task<ActividadResponse?> Get(int id);
        Task<Actividad> Update(int id, UpdateActividadRequest updateActividadRequest);
        Task<int> Desactivate(int id);
        Task<int> Activate(int id);
    }
}
