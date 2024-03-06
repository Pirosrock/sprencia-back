namespace Sprencia_Api.Entities.API.Actividades.Requests.Create
{
    public class CreateActividadRequest
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Resumen { get; set; }
        public bool Estado { get; set; }
    }
}
