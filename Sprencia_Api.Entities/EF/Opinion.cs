namespace Sprencia_Api.Entities.EF
{
    public class Opinion
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public int ActividadId { get; set; }
    }
}
