using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Propiedad.Application.UseCases.Propiedad.Command.CrearPropiedad;

namespace Propiedad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : Controller
    {
        private readonly IMediator _mediator;
        public PropiedadController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarPropiedad([FromBody] CrearPropiedadCommand command)
        { 
            var result=await _mediator.Send(command);
            return Ok(result);
        }
    }
}
