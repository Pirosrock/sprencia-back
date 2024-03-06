using Microsoft.EntityFrameworkCore;
using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }


        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Opinion> Opiniones { get; set;}
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Actividad_horarios> Actividad_Horarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>()
                .HasMany(x => x.Opinion);
            modelBuilder.Entity<Actividad_horarios>()
                .HasOne(x => x.Actividad);
            modelBuilder.Entity<Actividad_horarios>()
                .HasOne(x => x.Horario);


        }
    }
}
