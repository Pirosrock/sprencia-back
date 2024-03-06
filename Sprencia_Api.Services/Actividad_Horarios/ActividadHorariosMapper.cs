using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Services.Actividad_Horarios
{
    public class ActividadHorariosMapper
    {
        public static ActividadHorariosResponse ActividadHorariosToActividadHorariosResponse(Actividad_horarios actividad_Horarios)
        {
            return new ActividadHorariosResponse
            {
                Id = actividad_Horarios.Id,
                ActividadId = actividad_Horarios.ActividadId,
                HorarioID = actividad_Horarios.HorarioID,
                Horario = actividad_Horarios.Horario             
            };
        }

        public static IEnumerable<ActividadHorariosResponse> ListActividadHorariosToActividadHorariosResponse(IEnumerable<Actividad_horarios> actividades_Horarios)
        {
            foreach(var actividadHorario in actividades_Horarios)
            {
                yield return ActividadHorariosToActividadHorariosResponse(actividadHorario);
            }
        }
    }
}
