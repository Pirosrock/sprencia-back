using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sprencia_Api.Entities.API.Usuarios.Requests.Authenticate;
using Sprencia_Api.Entities.API.Usuarios.Requests.Create;
using Sprencia_Api.Entities.API.Usuarios.Responses;
using Sprencia_Api.Entities.EF;
using Sprencia_Api.Repositories.Usuarios;
using Sprencia_Api.Services.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sprencia_Api.Services.Usuarios
{
    public class UsersServices : IUsersServices
    {
        readonly IUsersRepository _usersRepository;
        readonly IConfiguration _configuration;
        readonly IEncryptService _encryptService;

        public UsersServices(IUsersRepository usersRepository, IConfiguration configuration, IEncryptService encryptService)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
            _encryptService = encryptService;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest)
        {
            Usuario? user = await _usersRepository.Get(authenticateRequest.Username);
            if(user == null)
            {
                throw new InvalidDataException("No se ha encontrado usuario con las credenciales indicadas");
            }
            var decryptedPassword = _encryptService.DecryptString(user.Contraseña);
            if (decryptedPassword != authenticateRequest.Contraseña)
            {
                throw new InvalidDataException("Credenciales no validas");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["JWT:ValidAudience"],
                Issuer = _configuration["JWT:ValidIssuer"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var authenticateResponse = new AuthenticateResponse
            {
                Id = user.Id,
                Username = user.UserName,
                Token = tokenHandler.WriteToken(token),
            };
            return authenticateResponse;
        }

        public async Task Register(RegisterUsersRequest registerUsersRequest)
        {
            var validator = new RegisterUsersRequestValidator();
            var result = validator.Validate(registerUsersRequest);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var userExist = await _usersRepository.Get(registerUsersRequest.UserName);
            if(userExist != null)
            {
                throw new InvalidDataException($"El usuario '{registerUsersRequest.UserName}' ya existe");
            }

            var NuevoUsuario = new Usuario
            {
                UserName = registerUsersRequest.UserName,
                Contraseña = _encryptService.EncryptString(registerUsersRequest.Contraseña)
            };

            await _usersRepository.Create(NuevoUsuario);

        }
    }
}
