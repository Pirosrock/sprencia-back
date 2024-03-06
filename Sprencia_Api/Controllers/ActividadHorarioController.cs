using Microsoft.AspNetCore.Mvc;
using Sprencia_Api.Entities.EF;
using Sprencia_Api.Services.Actividad_Horarios;

namespace Sprencia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadHorarioController : ControllerBase
    {
        readonly IActividad_HorariosServices _actividad_HorariosServices;

        public ActividadHorarioController(IActividad_HorariosServices actividad_HorariosServices)
        {
            _actividad_HorariosServices = actividad_HorariosServices;
        }


        [HttpGet]
        public async Task<IEnumerable<Actividad_horarios>> GetAll()
        {
            return await _actividad_HorariosServices.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Actividad_horarios>> GetByActivityId(int id)
        {
            return await _actividad_HorariosServices.GetByActivityId(id);
        }
    }
}
