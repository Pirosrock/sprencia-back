using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Services.Actividad_Horarios
{
    public class ActividadHorariosResponse
    {
        public int Id { get; set; }
        public int HorarioID { get; set; }
        public int ActividadId { get; set; }
        public Horario Horario { get; set; }
    }
}
