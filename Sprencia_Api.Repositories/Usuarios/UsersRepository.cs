using Microsoft.EntityFrameworkCore;
using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories.Usuarios
{
    public class UsersRepository : IUsersRepository
    {
        readonly DataBaseContext _dataBaseContext;

        public UsersRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task Create(Usuario usuario)
        {
            await _dataBaseContext.Usuarios.AddAsync(usuario);
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task<Usuario?> Get(string userName)
        {
            return await _dataBaseContext.Usuarios.Where(x => x.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<Usuario?> Get(string username, string contraseña)
        {
            return await _dataBaseContext.Usuarios.Where(x => x.UserName.ToLower() == username.ToLower() && x.Contraseña == contraseña).FirstOrDefaultAsync();
        }
    }
}
