using FluentValidation;
using Sprencia_Api.Entities.API.Opiniones.Create;
using Sprencia_Api.Entities.EF;
using Sprencia_Api.Repositories.Opiniones;

namespace Sprencia_Api.Services.Opiniones
{
    public class OpinionesServices : IOpinionesServices
    {
        readonly IOpinionesRepository _opinionesRepository;

        public OpinionesServices(IOpinionesRepository opinionesRepository)
        {
            _opinionesRepository = opinionesRepository;
        }


        public async Task<IEnumerable<OpinionResponse>> GetAll()
        {
            IEnumerable<Opinion> opiniones = await _opinionesRepository.GetAll();
            IEnumerable<OpinionResponse> opinionesResponse = OpinionesMapper.ListOpinionToOpinionResponse(opiniones);
            
           return opinionesResponse;
        }

        public async Task<IEnumerable<OpinionResponse?>> GetByActivityId(int activityId)
        {
            IEnumerable<Opinion?> opiniones = await _opinionesRepository.GetByActivityId(activityId);
            IEnumerable<OpinionResponse> opinionesResponse = OpinionesMapper.ListOpinionToOpinionResponse(opiniones);

            return opinionesResponse;
        }

        public async Task<Opinion> Post(CreateOpinionRequest createOpinionRequest)
        {
            var validator = new CreateOpinionRequestValidator();
            var result = await validator.ValidateAsync(createOpinionRequest);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var opinion = new Opinion()
            {
                Texto = createOpinionRequest.Texto,
                Fecha = createOpinionRequest.Fecha,
                ActividadId = createOpinionRequest.ActividadId
            };

            var newOpinion = await _opinionesRepository.Post(opinion);
            return newOpinion;
        }
        public async Task Delete(int id)
        {
            var afectedRows  = await _opinionesRepository.Delete(id);
            if(afectedRows == 0)
            {
                throw new InvalidDataException($"No existe una opinión que el id {id}");
            }
        }
    }
}
