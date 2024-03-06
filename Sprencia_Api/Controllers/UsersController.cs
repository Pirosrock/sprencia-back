using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprencia_Api.Entities.API.Usuarios.Requests.Authenticate;
using Sprencia_Api.Entities.API.Usuarios.Requests.Create;
using Sprencia_Api.Services.Usuarios;

namespace Sprencia_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUsersServices _userServices;

        public UsersController(IUsersServices userServices)
        {
            _userServices = userServices;
        }
        [Authorize]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUsersRequest registerUsersRequest)
        {
            await _userServices.Register(registerUsersRequest);
            return Created("", null);
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest authenticateRequest)
        {
            var authResponse =  await _userServices.Authenticate(authenticateRequest);
            return Ok(authResponse);
        }
    }
}
