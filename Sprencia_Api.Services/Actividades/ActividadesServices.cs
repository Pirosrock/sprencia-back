using FluentValidation;
using Sprencia_Api.Entities.API.Actividades.Requests.Create;
using Sprencia_Api.Entities.API.Actividades.Requests.Update;
using Sprencia_Api.Entities.API.Actividades.Responses;
using Sprencia_Api.Entities.EF;
using Sprencia_Api.Repositories.Actividades;
using Sprencia_Api.Services.Actividad_Horarios;

namespace Sprencia_Api.Services.Actividades
{
    public class ActividadesServices : IActividadesServices
    {
        readonly IActividadesRepository _actividadesRepository;
        readonly IActividad_HorariosServices _actividad_horariosServices;

        public ActividadesServices(IActividadesRepository actividadesRepository, IActividad_HorariosServices actividad_horariosServices)
        {
            _actividadesRepository = actividadesRepository;
            _actividad_horariosServices = actividad_horariosServices;
        }

        public async Task<Actividad> Create(CreateActividadRequest CreateActividadRequest)
        {
            var validator = new CreateActividadRequestValidator();
            var result = await validator.ValidateAsync(CreateActividadRequest);

            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var actividad = new Actividad()
            {
                Nombre = CreateActividadRequest.Nombre,
                Precio = CreateActividadRequest.Precio,
                Resumen = CreateActividadRequest.Resumen,
                Estado = CreateActividadRequest.Estado
            };
            var newActivity = await _actividadesRepository.Create(actividad);
            return newActivity;
        }

        public async Task<int> Desactivate(int id)
        {
            var updatesRows = await _actividadesRepository.Desactivate(id);
            if (updatesRows == 0)
            {
                throw new InvalidDataException($"No existe una activdad con el id {id}");
            }
            return updatesRows;
        }
        public async Task<int> Activate(int id)
        {
            var updatesRows = await _actividadesRepository.Activate(id);
            if (updatesRows == 0)
            {
                throw new InvalidDataException($"No existe una activdad con el id {id}");
            }
            return updatesRows;
        }

        public async Task<ActividadResponse?> Get(int id)
        {
            Actividad? actividad = await _actividadesRepository.Get(id);
            // LLamar al método de actividades_horariosServices (inyectar el servicio actividades_horariosServices
            IEnumerable<Actividad_horarios> actividadHorario = await _actividad_horariosServices.GetByActivityId(id);

            return ActividadesMapper.ActividadToActividadResponse(actividad, actividadHorario);
        }
         
        public async Task<IEnumerable<ActividadResponse>> Getall()
        {
            IEnumerable<Actividad> actividades = await _actividadesRepository.GetAll();

            List<ActividadResponse> actividadResponse = new List<ActividadResponse>();

            foreach (var actividad in actividades)
            {
                IEnumerable<Actividad_horarios> actividadHorario = await _actividad_horariosServices.GetByActivityId(actividad.Id);

                ActividadResponse actividadesResponse = ActividadesMapper.ActividadToActividadResponse(actividad, actividadHorario);
                actividadResponse.Add(actividadesResponse);
              
            }

            return actividadResponse;
        }

        public async Task<Actividad> Update(int id, UpdateActividadRequest updateActividadRequest)
        {
            UpdateActividadRequestValidator validator = new UpdateActividadRequestValidator();
            var result = await validator.ValidateAsync(updateActividadRequest);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _actividadesRepository.Update(id, updateActividadRequest);
            Actividad? actividad = await _actividadesRepository.Get(id);
            return actividad;

        }
    }
}
