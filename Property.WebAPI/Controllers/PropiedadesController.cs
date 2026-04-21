using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Property.Application.Dto;

namespace Property.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropiedadesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropiedadesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PropiedadDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetPropiedadesQuery());
            return Ok(result);
        }
    }
}