using Sprencia_Api.Entities.API.Usuarios.Requests.Authenticate;
using Sprencia_Api.Entities.API.Usuarios.Requests.Create;
using Sprencia_Api.Entities.API.Usuarios.Responses;

namespace Sprencia_Api.Services.Usuarios
{
    public interface IUsersServices
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest);
        Task Register(RegisterUsersRequest registerUsersRequest);
    }
}
