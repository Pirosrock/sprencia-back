namespace Sprencia_Api.Entities.API.Opiniones.Create
{
    public class CreateOpinionRequest
    {
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public int ActividadId { get; set; }
    }
}
