namespace Sprencia_Api.Entities.API.Actividades.Requests.Update
{
    public class UpdateActividadRequest
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Resumen { get; set; }
        public bool Estado { get; set; }
    }
}
