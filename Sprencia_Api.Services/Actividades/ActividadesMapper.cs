using Sprencia_Api.Entities.API.Actividades.Responses;
using Sprencia_Api.Entities.EF;
using Sprencia_Api.Services.Actividad_Horarios;
using Sprencia_Api.Services.Opiniones;

namespace Sprencia_Api.Services.Actividades
{
    public class ActividadesMapper
    {


        public static ActividadResponse ActividadToActividadResponse(Actividad actividad, IEnumerable<Actividad_horarios> actividad_Horarios)
        {
            return new ActividadResponse
            {
                Id = actividad.Id,
                Nombre = actividad.Nombre,
                Precio = actividad.Precio,
                Resumen = actividad.Resumen,
                Estado = actividad.Estado,
                Opinion = OpinionesMapper.ListOpinionToOpinionResponse(actividad.Opinion),
                Actividad_Horarios = ActividadHorariosMapper.ListActividadHorariosToActividadHorariosResponse(actividad_Horarios)

            };
        }

        public static IEnumerable<ActividadResponse> ListActividadToActividadResponse(IEnumerable<Actividad> actividades, IEnumerable<Actividad_horarios> actividad_Horarios)
        {
            foreach(var actividad in actividades)
            {

                yield return ActividadToActividadResponse(actividad, actividad_Horarios);
            }
        }
    }
}
