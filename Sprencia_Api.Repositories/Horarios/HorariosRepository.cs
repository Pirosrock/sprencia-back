using Microsoft.EntityFrameworkCore;
using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories.Horarios
{
    public class HorariosRepository  : IHorariosRepository
    {
        readonly DataBaseContext _context;

        public HorariosRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Horario>> GetAll()
        {
            return await _context.Horarios
                .ToListAsync();
        }
    }
}
