using Microsoft.EntityFrameworkCore;
using Sprencia_Api.Entities.API.Actividades.Requests.Update;
using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories.Actividades
{
    public class ActividadesRepository : IActividadesRepository
    {
        readonly DataBaseContext _context;

        public ActividadesRepository(DataBaseContext context)
        {
            _context = context;
        }



        public async Task<Actividad> Create(Actividad actividad)
        {
            var newActivity = await _context.Actividades.AddAsync(actividad);
            await _context.SaveChangesAsync();
            return await _context.Actividades
                .Include(o => o.Opinion)
                .Where(x => x.Id == actividad.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Desactivate(int id)
        {
            return await _context.Actividades
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(actividad => actividad
                .SetProperty(
                property => property.Estado,
                property => false));
        }
        public async Task<int> Activate(int id)
        {
            return await _context.Actividades
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(actividad => actividad
                .SetProperty(
                property => property.Estado,
                property => true));
        }

        public async Task<Actividad?> Get(int id)
        {
            return await _context.Actividades
                .Include(o => o.Opinion)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Actividad>> GetAll()
        {
            return await _context.Actividades
                .Include (o => o.Opinion)
                // .Include(a => a.Actividad_Horarios)
                .ToListAsync();
        }

        public async Task<int> Update(int id, UpdateActividadRequest updateActividadRequest)
        {
            return await _context.Actividades
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(actividad => actividad
                .SetProperty(
                    property => property.Nombre,
                    property => updateActividadRequest.Nombre)
                .SetProperty(
                    property => property.Resumen,
                    property => updateActividadRequest.Resumen)
                .SetProperty(
                    property => property.Precio,
                    property => updateActividadRequest.Precio)
                .SetProperty(
                    property => property.Estado,
                    property => updateActividadRequest.Estado));
           
           
        }
    }
}
