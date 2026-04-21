using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Application.UseCases.Propiedad.Command.CrearPropiedad;
using Property.Domain.Model.Propiedades;

namespace Property.WebAPI.Controllers
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

        [HttpPut("validar")]
        public async Task<IActionResult> ValidarPropiedad([FromBody] ValidarPropiedadCommand command)
        { 
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
