namespace Sprencia_Api.Entities.EF
{
    public class Actividad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Resumen { get; set; }
        public bool Estado { get; set; }
        public  List<Opinion?> Opinion { get; set; }
        //public List<Actividad_horarios?> Actividad_Horarios { get; set; }

    }
}
