using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Services.Opiniones
{
    public class OpinionesMapper
    {
        public static OpinionResponse OpinionToOpinionResponse(Opinion opinion)
        {
            return new OpinionResponse
            {
                ActividadId = opinion.ActividadId,
                Texto = opinion.Texto,
                Id = opinion.Id,
                Fecha = opinion.Fecha.ToString("dd-MM-yyyy")
            };
        }

        public static IEnumerable<OpinionResponse> ListOpinionToOpinionResponse(IEnumerable<Opinion> opiniones)
        {
            foreach(var opinion in opiniones)
            {
                yield return OpinionToOpinionResponse(opinion);
            }
        }
    }
}
