using Microsoft.EntityFrameworkCore;
using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories.Actividad_Horarios
{
    public class Actividad_HorariosRepository : IActividad_HorariosRepository
    {
        readonly DataBaseContext _context;

        public Actividad_HorariosRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actividad_horarios>> GetAll()
        {
            return await _context.Actividad_Horarios
                .Include(a => a.Actividad)
                .Include(b => b.Horario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Actividad_horarios>> GetByActivityId(int id)
        {
            return await _context.Actividad_Horarios
                .Where(x => x.ActividadId == id)
                .Include(a => a.Actividad)
                .Include(b => b.Horario)
                .ToListAsync();

        }
    }
}
