using Sprencia_Api.Services.Actividad_Horarios;
using Sprencia_Api.Services.Opiniones;

namespace Sprencia_Api.Entities.API.Actividades.Responses
{
    public class ActividadResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Resumen { get; set; }
        public bool Estado { get; set; }
        public IEnumerable<OpinionResponse?> Opinion { get; set; }
        public IEnumerable<ActividadHorariosResponse> Actividad_Horarios { get; set; }


    }
}
