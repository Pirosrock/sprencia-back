using Sprencia_Api.Entities.EF;

namespace Sprencia_Api.Repositories.Usuarios
{
    public interface IUsersRepository
    {
        Task<Usuario?> Get(string userName);
        Task Create(Usuario usuario);
        Task<Usuario?> Get(string username, string contraseña);
    }
}
