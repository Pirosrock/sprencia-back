namespace Sprencia_Api.Entities.EF
{
    public class Actividad_horarios
    {
        public int Id { get; set; }
        public int HorarioID { get; set; }
        public int ActividadId { get; set; }
        public Horario Horario { get; set; }
        public Actividad Actividad { get; set; }
    }
}
