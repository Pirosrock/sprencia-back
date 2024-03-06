using Microsoft.EntityFrameworkCore;
using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories.Opiniones
{
    public class OpinionesRepository : IOpinionesRepository
    {

        DataBaseContext _context;

        public OpinionesRepository(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;

        }


        public async Task<IEnumerable<Opinion>> GetAll()
        {
            return await _context.Opiniones
                .ToListAsync();
        }

        public async Task<IEnumerable<Opinion?>> GetByActivityId(int activityId)
        {
            return await _context.Opiniones
                .Where(x => x.ActividadId == activityId)
                .ToListAsync();
        }

        public async Task<Opinion> Post(Opinion opinion)
        {
            var newOpinion = await _context.Opiniones.AddAsync(opinion);
            await _context.SaveChangesAsync();
            return await _context.Opiniones
                .Where(x => x.Id == opinion.Id).FirstOrDefaultAsync();
        }

        public async Task<int> Delete(int id)
        {
            return await _context.Opiniones
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
