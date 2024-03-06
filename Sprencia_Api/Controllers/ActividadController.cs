using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprencia_Api.Entities.API.Actividades.Requests.Create;
using Sprencia_Api.Entities.API.Actividades.Requests.Update;
using Sprencia_Api.Entities.API.Actividades.Responses;
using Sprencia_Api.Entities.EF;
using Sprencia_Api.Services.Actividades;

namespace Sprencia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        readonly IActividadesServices _actividadesServices;

        public ActividadController(IActividadesServices actividadesServices)
        {
            _actividadesServices = actividadesServices;
        }

        [HttpGet]
        public async Task<IEnumerable<ActividadResponse>> GetAll()
        {
            return await _actividadesServices.Getall();
        }

        [HttpGet("{id}")]
        public async Task<ActividadResponse?> Get(int id)
        {
            return await _actividadesServices.Get(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<Actividad> Post([FromBody] CreateActividadRequest actividad)
        {
            return await _actividadesServices.Create(actividad);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<Actividad> Put(int id, [FromBody] UpdateActividadRequest updateActividadRequest)
        {
           return await _actividadesServices.Update(id, updateActividadRequest);
           
        }

        [Authorize]
        [HttpPut("desactivar/{id}")]
        public async Task<IActionResult> Desactivate(int id)
        {
            await _actividadesServices.Desactivate(id);
            return Ok();
        }

        [Authorize]
        [HttpPut("activar/{id}")]
        public async Task<IActionResult> Activate(int id)
        {
            await _actividadesServices.Activate(id);
            return Ok();
        }
    }
}
