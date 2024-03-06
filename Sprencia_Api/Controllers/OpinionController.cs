using Microsoft.AspNetCore.Mvc;
using Sprencia_Api.Entities.API.Opiniones.Create;
using Sprencia_Api.Entities.EF;
using Sprencia_Api.Services.Opiniones;

namespace Sprencia_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        readonly IOpinionesServices _opinionesServices;

        public OpinionController(IOpinionesServices opinionesServices)
        {
            _opinionesServices = opinionesServices;
        }

        [HttpGet]

        public async Task<IEnumerable<OpinionResponse>> GetAll()
        {
            return await _opinionesServices.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<OpinionResponse?>> GetOpinion(int id)
        {
            return await _opinionesServices.GetByActivityId(id);
        }

        [HttpPost]
        public async Task<Opinion> PostOpinion([FromBody] CreateOpinionRequest opinion)
        {
            return await _opinionesServices.Post(opinion);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _opinionesServices.Delete(id);
            return Ok();
        }



    }
}
