using Microsoft.AspNetCore.Mvc;
using Sprencia_Api.Entities.EF;
using Sprencia_Api.Services.Horarios;

namespace Sprencia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        readonly IHorariosServices _horariosServices;

        public HorarioController(IHorariosServices horariosServices)
        {
            _horariosServices = horariosServices;
        }
        [HttpGet]
        public async Task<IEnumerable<Horario>> GetAll()
        {
            return await _horariosServices.Getall();
        }
    }
}
